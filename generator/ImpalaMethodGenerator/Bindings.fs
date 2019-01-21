module Bindings

open System.IO
    // Internal Representation for generating C# programmably. 
    
    // These are good for C# in general, not just Impala methods. They don't
    // cover the *entire* language (e.g: no while loops, array literals, etc.)
    // but can be extended relatively easily to do so.

    // Additionally, we do not make any attempt to distinguish between l-values 
    // and r-values here. We entrust general syntax verification to the C# compiler
    // in order to make our program representation more concise.

    // Just math for now.
    type Infix = ADD | SUB | MUL | DIV | MOD | EQ | GT | LT | GTE | LTE | AND | OR
    type Prefix = NEG | NOT 

    // Composable expression.
    type Expr = 
      | IConst of int 
      | SConst of string
      | BConst of bool
      | Var of string
      | Binop of Infix * Expr * Expr 
      | Unop  of Prefix * Expr 
      | Ternary  of Expr * Expr * Expr 
      | ExpTuple of Expr list
      | ConstrObject of CSType * Expr list
      | ConstrArray of CSType * Expr
      | Index of Expr * Expr
      | Property of Expr * string
      | Method of Expr * string * Expr list
      | Lambda of Expr * Expr
      | Call  of string * Expr list
 
    // Composable types
    and CSType = 
      | INT 
      | BOOL
      | INFER  // Used to denote that the type should be inferred (e.g: var)
      | Param of string // Type parameter (or user-defined string.)
      | Array of CSType 
      | TTuple of CSType list
      | Composite of CSType * CSType list

    // Loops within a range, not an arbitrary condition.
    type ForLoop = { 
       variable : Expr;
       start : Expr;
       stop : Expr; 
       stride : Expr;
       body : Stmt list;
    }

    and Conditional = { 
       case : Expr; 
       _if : Stmt list;
       _else : Stmt list option;
    }

    // Base program statements (within a function)
    and Stmt = 
      | EMPTY   // Useful for spacing & formatting.
      | Simple of Expr
      | DeclAssign of CSType * Expr * Expr
      | Assign of Expr * Expr
      | Condition of Conditional
      | Loop of ForLoop
      | Parallel of ForLoop
      | Block of Stmt list 
      | Return of Expr

    // Main program element
    and Function = {
      modifiers : string list
      name : string
      typ : CSType
      parameters : CSType list
      args : (CSType * Expr) list
      constraints : (CSType * CSType) list // on types, e.g. where T : SuperT
      body : Stmt list;
    }

    and Class = {
      modifiers : string list
      name : string
      body : Function seq            // Could be quite large. Let's have this one be lazy
    }

    type GStmt =
      | EMPTY_STM // For formatting
      | Class of Class
      | BlockComment of string list
      | Using of string list * string list // modifier list * namespace list
      | Namespace of string * GStmt list

    type Program = GStmt list

    // Type Formatters! Pretty print exprs, statements, the whole deal.
    let space = "    " // 4-spaces. No tabs.

    let FmtBinop = function 
      | ADD -> "+"
      | SUB -> "-"
      | MUL -> "*"
      | DIV -> "/"
      | MOD -> "%"
      | AND -> "&&"
      | OR  -> "||"
      | GT  -> ">"
      | LT  -> "<"
      | EQ  -> "=="
      | GTE -> ">="
      | LTE -> "<="
 
    let FmtUnop = function
      | NEG -> "-"
      | NOT -> "!"

    let rec FmtTup fn args = 
        let tup'd = String.concat "," (List.map fn args) in 
        if (List.length args) > 1  then "(" + tup'd + ")" else tup'd  

    let rec FmtArgs args = args |> List.map FmtExpr |> String.concat "," 

    and FmtExpr = function 
      | Var v -> v
      | IConst i -> sprintf "%d" i 
      | SConst s -> s 
      | BConst b -> if b then "true" else "false"
      | ExpTuple exprs -> FmtTup FmtExpr exprs 
      | Binop (op,s1,s2) ->        sprintf "(%s %s %s)"   (FmtExpr s1) (FmtBinop op) (FmtExpr s2)
      | Unop (op,s) ->             sprintf "(%s %s)"      (FmtUnop op) (FmtExpr s)
      | Call (name,args) ->        sprintf "%s(%s)"       name (FmtArgs args)
      | Method (expr,name,args) -> sprintf "%s.%s(%s)"    (FmtExpr expr) name (FmtArgs args)
      | ConstrObject (typ,args) -> sprintf "new %s(%s)"   (FmtType typ) (FmtArgs args)
      | ConstrArray (typ,arg) ->   sprintf "new %s[%s]"   (FmtType typ) (FmtExpr arg)
      | Index (obj,idx) ->         sprintf "%s[%s]"       (FmtExpr obj) (FmtExpr idx)
      | Lambda (arg,exp) ->        sprintf "%s => %s"     (FmtExpr arg) (FmtExpr exp)
      | Property (obj,str) ->      sprintf "%s.%s"        (FmtExpr obj) str
      | Ternary (c,i,e) ->         sprintf "%s ? %s : %s" (FmtExpr c) (FmtExpr i) (FmtExpr e)

    and FmtType = function 
      | INT -> "int"
      | BOOL -> "bool"
      | INFER -> "var"
      | Param t -> t
      | Array t -> FmtType t + "[]"
      | TTuple ts -> FmtTup FmtType ts  
      | Composite (typ,typs) -> sprintf "%s<%s>" (FmtType typ) (typs |> List.map FmtType |> String.concat ",")

    let rec FmtStmt indent stm =
      let next = indent + space
      let fmtblk b = FmtStmt indent (Block b) 
      let formatted = 
        (match stm with
        | EMPTY -> ""
        | Simple e -> (FmtExpr e) + ";"
        | DeclAssign (t,v,e) -> sprintf "%s %s = %s;" (FmtType t) (FmtExpr v) (FmtExpr e)
        | Assign (v,e) -> sprintf "%s = %s;" (FmtExpr v) (FmtExpr e)
        | Return e -> "return " + FmtExpr e + ";"
        | Block (b) ->
           "\n"+ indent + "{\n" + String.concat ("\n") (List.map (FmtStmt next) b) + "\n" + indent + "}"
    
        | Condition c -> 
          sprintf "if (%s) %s" (FmtExpr c.case) (fmtblk c._if) +
            (match c._else with 
            | None -> ""
            | Some s -> fmtblk s)
      
        | Loop l -> 
          sprintf "for (%s %s; %s )%s"  //Statements come with semicolons
            (FmtStmt "" (DeclAssign (INT,l.variable,l.start)))  
            (FmtExpr (Binop (LT,l.variable,l.stop)))
            (if l.stride = IConst 1 then (FmtExpr l.variable) + "++" 
             else (FmtExpr l.variable) + " += " + (FmtExpr l.stride))
            (fmtblk l.body)

        | Parallel l -> 
          sprintf "Parallel.For( %s, %s, %s => %s);"
            (FmtExpr l.start) (FmtExpr l.stop) (FmtExpr l.variable) (fmtblk l.body))

       in
       indent + formatted
    
    let FmtConstraints indent constrs = 
      let fmt (param,constr) = sprintf "where %s : %s" (FmtType param) (FmtType constr)
      let strs = String.concat "  " (List.map fmt constrs)
      (if List.length constrs > 0 then indent + strs else "") 

    let FmtFunction indent (func : Function) = 
      let space' = indent + space
      let args = func.args |> List.map (fun (t,s) -> FmtType t + " " + (FmtExpr s)) |>  String.concat ", " 
      let mods = String.concat " " func.modifiers
      let cons = FmtConstraints space' func.constraints
      let pars = func.parameters |> List.map FmtType |> String.concat "," 
      let sign = sprintf "%s %s %s<%s>\n%s(%s)\n%s" mods (FmtType func.typ) (func.name) pars indent args cons 
      let body = FmtStmt (space') (Block func.body) 
      indent + sign + body + "\n\n"
    
    let rec PrintGstmt printer indent = function 
      | EMPTY_STM -> printer ("\n")
      | Using (quals,mods) -> 
            let mods' = if List.length mods > 0 then (String.concat " " mods + " ") else ""
            printer (indent + sprintf ("using %s%s;\n") (mods') (String.concat "." quals))
      | BlockComment (comments) ->
            let fmtc c = indent + sprintf "/// %s" c
            let lines =  indent + "///<summary>" :: List.map fmtc comments @ [indent + "///</summary>"]
            printer (String.concat "\n" lines + "\n")
      | Class (cdefn) ->
            let signature = cdefn.modifiers @ ["class";cdefn.name] |> String.concat " "
            let start = indent + signature + "\n" + indent + "{\n\n"
            let finish = "\n" + indent + "}\n" 
            printer start;
            Seq.iter (fun fn -> printer (FmtFunction (indent + space) fn)) cdefn.body;
            printer finish;
      | Namespace (name,stms) -> 
            let name = indent + "namespace " + name + "\n" + indent + "{\n"
            let finish = "\n" + indent + "}" 
            printer (name)
            List.iter (PrintGstmt printer (indent + space)) stms
            printer (finish)
            
    let PrintProgram filename (program : Program) = 
        let fprint s = File.AppendAllText(filename,s) in 
        List.iter (PrintGstmt fprint "") program
                 