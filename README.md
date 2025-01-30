# Redmage manafication quick reference tool
Tool that simulates should you hold your manafication (cd 110s) for embolden (cd 120s) during a set killtime.
If you would gain an extra usage, the tool will hold if possible and use it on cd if not possible. 

## Example
Inputs:   
Killtime: "8:05"   
How many seconds in first cast: "8"  

Prints:    
Kill time: 8:05    
Casts: 5    
Holds: 2     
Manafication casts:    
0:08 | Opener   
2:08 | Hold    
4:08 | Hold    
5:58 | OnCD    
7:48 | OnCD    
