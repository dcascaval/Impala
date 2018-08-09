Attempts are ongoing to create optimised methods that additionally provide high amounts of code reuse. 

Current Efforts:


**8 Aug 2018**

	- Providing a ZipMxN funtion
		- This runs into the GH_Structure<T>.DuplicateCast() not returning a value issue.
		- Upon writing our own casting mechanism we find that this mechanism works, but suffers some performance drawbacks. 
		- This either takes a performance hit (casting from specific -> generic on input), or a safety one (inputting generics in the first place, which then later necessitates checking conversion correctness manually.)
		
	- Side by side comparison:
		- Zip3x3 vs Zip3xN(3)
			- Key differences: 
				- Zip3x3 uses tuples with specific types and avoids casts
				- Zip3xN uses IGH_Goo arrays which require heavy casting.
			- Profiling the overall component indicates that Zip3xN is significantly (80%) slower than Zip3x3. 
			- Profiling the native code calls in a sequential benchmark reveals no difference in their performance.
			- Profiling the just the Zip() calls reveal a marginal (10-20%) difference in the runtime, all of which differs in how long the function spends in calls to external code. This indicates a compiler optimisation that is enabled in one zip call but not another.
			- However, casting the overall structure back into a specific GH type (or the equivalent) takes up a large amount of time after the computation stage. 
				- Working around this using a custom implementation of DA to set parameters may be an option
				- Manually casting it is still a significant (50%) improvement over letting it figure out how to cast itself to the output parameters. 
			- Generics are really difficult to wrangle with w/ respect to GH_Structure types
			
	- Possible (longer-term) solutions to the Generics issue:
		- Expression trees to define/predefine a compiled set of functions via a parameter set
		- Custom-reimplementation of the IGH_DataAccess interface to get over DA's issues
			- Along with this, a custom ImpalaStructure that allows rapid computation (array-based, unsorted list, etc.)
			- TypeConversions to necessitated GH_Structure