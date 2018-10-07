import pandas as pd
import numpy as np
from sklearn import datasets, linear_model
import matplotlib.pyplot as plt

def readFile(filename):
    data = pd.read_csv(filename, sep=",", usecols=[0, 6], names=['Date', 'Price'], header=0)
    # returns
    returns = np.array(data["Price"][:-1], np.float) / np.array(data["Price"][1:], np.float) - 1 #append returns to the dataframe, Need to append nan since returns contains always one less item
    data["Returns"] = np.append(returns, np.nan)
    data.index = data["Date"]
    return data

nasdaqFile = 'C:/Users/shallur/Documents/ML-Data/Nasdaq.csv'
googFile= 'C:/Users/shallur/Documents/ML-Data/GOOG.csv'
spFile = 'C:/Users/shallur/Documents/ML-Data/SP_500.csv'
oilFile = 'C:/Users/shallur/Documents/ML-Data/USO.csv'
xomFile = 'C:/Users/shallur/Documents/ML-Data/XOM.csv'

googData = readFile(googFile)
nasdaqData = readFile(nasdaqFile)
spData = readFile(spFile)
oilData = readFile(oilFile)
xomData = readFile(xomFile)

#we're going to use reshape(-1, 1)
#Notice, however, that while setting up both X and Y data, we exclude the last element from our pandas
#[0:-1] excludes last element because that was the special value nan that can lead to problems when we invoke the regression algorithm on the data
xData = nasdaqData["Returns"][0:-1].reshape(-1, 1)
yData = googData["Returns"][0:-1]

#so far we have used pandas and numpy. Now, we will use Scikit for regression
goodGoogModel = linear_model.LinearRegression()
print(goodGoogModel.fit(xData, yData)) # this gives us the regression line

# for R2
print(goodGoogModel.score(xData, yData))

#coef attribute returns the coefficients, this returns an array with only the value of B
print(goodGoogModel.coef_)

#intercept
print((goodGoogModel.intercept_))

#residues
print(goodGoogModel.residues_)

# plotting
print('Plotting')
plt.scatter(xData, yData, color='black')
plt.plot(xData, goodGoogModel.predict(xData), color='blue', linewidth=3)

# set the ticks
plt.xticks()
plt.yticks()
plt.show()




