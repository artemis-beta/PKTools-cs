COMPILER=mcs
EXAMPLES=${PWD}/examples
SOURCE=${PWD}/source
OUTDIR=${PWD}/executables

all: lorentz matrix addvars triangle
	mkdir -p ${OUTDIR}
	mv ${EXAMPLES}/*.exe ${OUTDIR}

lorentz:
	${COMPILER} ${EXAMPLES}/LorentzVectors.cs ${SOURCE}/*.cs
	rm -rf ${SOURCE}/*.exe

matrix:
	${COMPILER} ${EXAMPLES}/Matrix_Example.cs ${SOURCE}/*.cs
	rm -rf ${SOURCE}/*.exe

addvars:
	${COMPILER} ${EXAMPLES}/AddPKVars.cs ${SOURCE}/*.cs
	rm -rf ${SOURCE}/*.exe

triangle:
	${COMPILER} ${EXAMPLES}/PKTriangleExample.cs ${SOURCE}/*.cs
	rm -rf ${SOURCE}/*.exe

clean:
	rm -rf ${OUTDIR}/*.exe
