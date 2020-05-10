# -----------------------------------------------------------------------------------------------------------------------------
# Python script that searches for time taken line for each core number in log file and print them as a list in another text file.
# Lewis Sharpe
# Date: 04/05/20
# -----------------------------------------------------------------------------------------------------------------------------
with open('LOG_TESTnewrange', 'r') as f:
  with open("output.txt", "w") as f1:
    for line in f:
        if 'Time taken for core number' in line:
		f1.write(line)
# -----------------------------------------------------------------------------------------------------------------------------
