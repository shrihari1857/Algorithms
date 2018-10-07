import pandas as pd
import numpy as np
import statsmodels.api as sm

spFile = 'C:/Users/shallur/Documents/ML-Data/SP_500.csv'
googFile= 'C:/Users/shallur/Documents/ML-Data/GOOG.csv'

#get the goog and sp500 files
goog = pd.read_csv(spFile, sep=",", usecols=[0, 5], names=['Date', 'Goog'], header=0)
sp = pd.read_csv(googFile, sep=",", usecols=[0, 5], names=['Date', 'SP500'], header=0)

goog['SP500'] = sp['SP500'] # get the sp500 price to the goog dataframe
goog['Date'] = pd.to_datetime(goog['Date'], format='%Y-%m-%d')  #ensure the Date column is rightly formatted


#important step - we need to convert goog and sp500 into returns
# The basic idea is that we never want to carry out regressions using smoothly trending data and so we convert
#such data into returns, that is percentage changes of adjacent points

# let's first sort our data frame with dates in ascending order
goog = goog.sort_values(['Date'], ascending=[True])

# since we need to find the returns only on the numeric prices and not on the date column
#we create a dictionary where keys are the column names and values are the column types
dict(goog.dtypes)
returns = goog[[key for key in dict(goog.dtypes) if dict(goog.dtypes)[key] in ['float64', 'int64']]].pct_change()

# we removed the date column from returns, let's add it back
returns['Date'] = goog['Date']

#we'll now add a column of all 1's to the x-variables. Required in Python for Logistic regression since we're going to use stats model in Python for regression
returns['Intercept'] = 1

# we need to exclude the first row that contains NaN, this is due to returns
# we do this by converting into a numpy array
# we now have setup or explanatory or x variables in a format that can be passed into the stats model logistic regression
xData = np.array(returns[['Goog', 'SP500', 'Intercept']][1:-1])    # look screen shot for negative python indices, in x data we omit the first and the last row

#let's setup our Y variable
# remembere, here, the Y variable needs to be categorical and hence we're converting Google's returns into a binary variable
# here, in Y data we omit the first two rows, this is to ensure x and y have the same number of rows, but different starting points
# this choice of indices are requires in order to get exactly the right lineup of the Y variables and the X variables
yData = (returns['Goog'] > 0)[2:]

# Remember that the model that we are trying to fit seeks to explain moves in Google stock return using the
# previous month's return on the S&P

# we'll now invoke the stats model
logit = sm.Logit(yData, xData)
result = logit.fit()
newResults = result.predict(xData)

#let's convert these values into up or down by using a threshold of 0.5, we can do this easily in python
#r1 = zip(yData, result.predict(xData) > 0.5)
#print(goog.dtypes)
#result.predict(xData)
#r2 = zip(yData, result.predict(xData) > 0.5)
newList = []
for item in newResults:
    if item < 0.5:
        newList.append(False)
    else:
        newList.append(True)

print(newList)