# Impala
###### A multithreaded library of performative C# components for Grasshopper.

____

Impala replicates common bottleneck operations with a focus on efficiency, allowing complex defiitions and static simulations to make use of all available computational capacity. This is primarily evident in scripts that deal with thousands of objects or rely heavily on physically-based information and computation. 

Impala focuses primarily on replicating existing Grasshopper functionality and developing an environment suitable to seamless integration of performant or multithreaded computation within GH. To this end it currently contains three types of components:
* Components that perform identical (or nearly identical) operations to existing Grasshopper components, but do so using a parallel strategy or a better algorithmic complexity (ex: `Closest Point`, `Halton`)
* Components that replicate expensive Grasshopper operation sets and use imperative methods to significantly reduce the time and space needed to obtain a result (ex: `Closest Curve Closest Point`, `MeshFlow`)
* Components that limit Grasshopper's type-casting system in exchange for performance gains on larger inputs (ex: `QuickMath`, `QuickDivide`)

Additionally, performance is improved relative to native GH by exposing "threshold" parameters wherever possible - allowing the user to specify under which conditions they do not want the result of an operation, significantly speeding up the computation in these cases.
	
___

Impala adapts Grasshopper's default logic for operating on multiple trees simultaneously - however, this is still being tested. The primary goal is to extend Grasshopper's capabilities (by allowing a wider range of expensive operations) while maintaining the flexibility that GH's associative model lends to designers. Impala provides a series of public, generic methods that operate on `GH_Structure<T>` and provide standard and parallel functional operations (Map, Zip, Reduce, etc.) with integrated, user-defined error checking operations. These are part of `Impala.Generic` and can be used in any other projects. 
	
A set of test files and extensive benchmarking results provide examples (and, where applicable, guarantees of correctness against an equivalent native GH baseline implementation) for all Impala components, as well as a short set of analysis notes for each of them specifying the best use-cases. 

____
	
Additional goals for future development include:
* Composition of other expensive operations (occlusion, intersection)
* Automated integration of Impala components in the form of a macro that searches for locations in a script where Impala could improve GH functionality and substituting the analogous component
* Allowing inter-component parallelism within a group. By maintaining constant inputs and outputs in a group of components, their operation set can be run in parallel, making use of Grasshopper's already visually-explicit dependency graph to structure the computation. This can speed up definitions that don't have a large-operation bottleneck, but may have to perform multiple disjoint sets of computations.
	
	
	
	
	
	
