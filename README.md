I. Instructions

1. Build/run the project
2. Check the output in the out.txt file
3. If you need different input, modify the input.txt file and run the project again

II. Approach
Each robot has a position (x,y) and an orientation (N,S,E,W) hence the the Position model and orientation enum
Then the commands L (Left), R(Right), F(Foward) which are simply change change in orientation and change in position based on the orientation, hence the Command enum and the Robot class which has a method to execute the commands.
The main program reads the input file, creates the robots and executes the commands, then writes the output to the output file. The program also keeps track of lost robots and their last positions to avoid losing more robots in the same position and orientation.

III. Tech choice  & Implementation
- C# 14.0
- .NET 10.0
-Command pattern, OOP principle(Here and there) and simple file I/O for reading and writing the input and output files.

This choice was just made based on habit,  but also it OOP and  C# is a good fit for this problem, and .NET 10.0 is the latest version with the best performance and features. 
The project is simple enough that it doesn't require any additional libraries or frameworks.
