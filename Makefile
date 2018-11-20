COMPILER=mcs
EXAMPLES=${PWD}/examples
SOURCE=${PWD}/source
OUTDIR=${PWD}/executables

all:
	${COMPILER} ${EXAMPLES}/*.cs ${SOURCE}/*.cs
	rm -rf ${SOURCE}/*.exe
	mkdir -p ${OUTDIR}
	mv ${EXAMPLES}/*.exe ${OUTDIR}

clean:
	rm -rf ${OUTDIR}/*.exe
