# ---------------------------------------------------------------------------------------------
# Script automates run of algorithm for every iteration between seq, 1 to 48 cores and prints times taken for each iteration
# Lewis Sharpe
# Date: 04/05/2020
# Run script with command: 'bash ./bash_fillarray.sh 1>LOG &'
# ---------------------------------------------------------------------------------------------

for i in $(seq 1 48 $END); do 
SECONDS=0;
# echo -n "**** Core number $i ****"
mono FillArray_PInvoke.exe; 
echo -n "###Time taken for core number $i:" $SECONDS "seconds"
done

# ---------------------------------------------------------------------------------------------
