COMPILER=mcs
EXAMPLES=${PWD}/examples
SOURCE=${PWD}/source
OUTDIR=${PWD}/executables

all: lorentz matrix
	mkdir -p ${OUTDIR}
	mv ${EXAMPLES}/*.exe ${OUTDIR}

lorentz:
	${COMPILER} ${EXAMPLES}/LorentzVectors.cs ${SOURCE}/*.cs
	rm -rf ${SOURCE}/*.exe

matrix:
	${COMPILER} ${EXAMPLES}/Matrix_Example.cs ${SOURCE}/*.cs
	rm -rf ${SOURCE}/*.exe

clean:
	rm -rf ${OUTDIR}/*.exe
