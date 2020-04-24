for i in $(seq 1 48 $END); do
echo -n "**** NUMBER OF CORES: $i ****"
mono FillArray_PInvoke.exe; done
