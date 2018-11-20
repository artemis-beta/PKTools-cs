# PKTools-cs
The C# version of the PKTools framework, a project for practicing and improving coding but also creating useful classes with a physics theme.

## Running Examples
To build and run the examples in Linux you will need to install `mcs` compiler and `mono` for running the executables within your distribution.
The examples are then built within the repository main directory using:

```
make -j4
```

This will place the built scripts within a new directory called `executables`. To run an example use the command:

```
mono example_file.exe
```
