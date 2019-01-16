open System

type Binop = ADD | SUB | MUL | DIV | MOD | EQ | GT | LT | GTE | LTE | AND | OR

type Unop = NEG | NOT 

type Expr = 
  | IConst of int 
  | SConst of string
  | BConst of bool
  | Var of string
  | Binop of Binop * Expr * Expr 
  | Unop  of Unop * Expr
  | Tern  of Expr * Expr * Expr 
  | Construct of CSType * Expr list
  | Method of Expr * string * Expr list
  | Call  of string * Expr list
 
and CSType = 
  | INT 
  | BOOL
  | INFER 
  | Param of string 
  | Array of CSType 
  | Tuple of CSType list
  | Composite of CSType * CSType list

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

and Stmt = 
  | DeclAssign of CSType * Expr * Expr
  | Assign of Expr * Expr
  | Condition of Conditional
  | Loop of ForLoop
  | Parallel of ForLoop
  | Block of Stmt list 
  | Return of Expr

and Function = {
  name : string; 
  typ : CSType;
  args : (CSType * Expr) list
  constraints : (CSType * CSType) list
  body : Stmt list;
}

type Program = Function list

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

let rec FmtArgs args = (String.concat "," (List.map FmtExpr args))

and FmtExpr = function 
  | IConst i -> sprintf "%d" i 
  | SConst s -> s 
  | BConst b -> if b then "true" else "false"
  | Var v -> v
  | Binop (op,s1,s2) -> sprintf "(%s %s %s)" (FmtBinop op) (FmtExpr s1) (FmtExpr s2)
  | Unop (op,s) -> sprintf "(%s %s)" (FmtUnop op) (FmtExpr s)
  | Call (name,args) -> sprintf "%s(%s)" name (FmtArgs args)
  | Method (expr,name,args) -> sprintf "%s.%s(%s)" (FmtExpr expr) name (FmtArgs args)
  | Construct (typ,args) -> sprintf "new %s(%s)" (FmtType typ) (FmtArgs args)
  | Tern (c,i,e) -> sprintf "%s ? %s : %s" (FmtExpr c) (FmtExpr i) (FmtExpr e)

and FmtType = function 
  | INT -> "int"
  | BOOL -> "bool"
  | INFER -> "var"
  | Param t -> t
  | Array t -> FmtType t + "[]"
  | Tuple ts -> let types = String.concat "," (List.map FmtType ts) in 
                if (List.length ts) > 1  then "(" + types + ")" else types  
  | Composite (typ,typs) -> sprintf "%s<%s>" (FmtType typ) (String.concat "," (List.map FmtType typs))

let rec FmtStmt indent stm =
  let next = indent + "\t" in
  let fmtblk b = FmtStmt indent (Block b) in
  let formatted = 
    (match stm with
    | DeclAssign (t,v,e) -> sprintf "%s %s = %s;" (FmtType t) (FmtExpr v) (FmtExpr e)
    | Assign (v,e) -> sprintf "%s = %s;" (FmtExpr v) (FmtExpr e)
    | Return e -> "return " + FmtExpr e + ";"

    | Block (b) ->
       "{\n" + String.concat ("\n" + indent) (List.map (FmtStmt next) b) + "\n" + indent + "}"
    
    | Condition c -> 
      sprintf "if (%s) %s" (FmtExpr c.case) (fmtblk c._if) +
        (match c._else with 
        | None -> ""
        | Some s -> fmtblk s)
      
    | Loop l -> 
      sprintf "for (%s;%s;%s += %s)%s" 
        (FmtStmt "" (DeclAssign (INT,l.variable,l.start))) 
        (FmtExpr (Binop (LT,l.variable,l.stop)))
        (FmtExpr l.variable) (FmtExpr l.stride)
        (fmtblk l.body)

    | Parallel l -> 
      sprintf "Parallel.For(%s,%s,%s => \n %s);"
        (FmtExpr l.start) (FmtExpr l.stop) (FmtExpr l.variable) (fmtblk l.body))
   in
   indent + formatted

let FmtConstraint (param,constr) = 
  sprintf "where %s : %s" (FmtType param) (FmtType constr)

let FmtFunction (func : Function) = 
  let args = String.concat "," (List.map (fun (t,s) -> FmtType t + " " + (FmtExpr s)) func.args) in
  let sign = sprintf "%s %s\n(%s)" (FmtType func.typ) (func.name) args in
  let cons = String.concat "\n\t" (List.map FmtConstraint func.constraints) in 
  let body = FmtStmt "\t" (Block func.body) in
  sign + cons + body

let FmtProgram = 
  List.map (FmtFunction)
 
let range n = 
  List.init n (id)

let maprange n f =  
  List.map f (range n)
 
let in_param nth =  
    let letter n = Char.ConvertFromUtf32 n in
    Param (String.replicate (nth / 13) (letter (nth % 13)))

let out_param nth = 
    let letter n = Char.ConvertFromUtf32 n in
    Param (String.replicate (nth / 13) (letter ((nth % 13) + 13)))

let GH_Structure types =
    Composite (Param "GH_Structure", types)

let declareResults n =  
    let result i =
        let var = sprintf "result%d" i in
        DeclAssign (INFER,Var var,Construct(GH_Structure [out_param i],[]))
    in
    range n |> List.map result


// let red1x1 rdx out = 
//   let s = sprintf in 
//   let results = maprange rdx (fun i -> Var (s"redux_t%d" i) ) in 
  
//   let decls = List.map (fun r -> DeclareAssign (INFER,r,Composite(Param "GH_Structure",[Param "A"]))) results in 
//   []

