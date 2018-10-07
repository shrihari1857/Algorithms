#this helps parse html
from bs4 import BeautifulSoup
#pandas is a data analysis package
import pandas as pd
import numpy as np
import math as mth

datafile = "C:/Users/shallur/Documents/ML-Data/titanicdata.htm"

#open and parse the html elements
#Beautiful Soup (BS) creates a complete hierarchy of the html elements in the web page
with open(datafile, encoding='ISO-8859-1') as f:
    soup = BeautifulSoup(f, "html.parser")


#let's get the 'table' element
table = soup.find('table')

#read the data in the library using pandas, data here is a dataframe(DF)
#this method actually returns a list of DFs, one DF for each DF for each table element in the html
# since we know only one table exists in the html, we pick the first one
data = pd.read_html(str(table), flavor='bs4')[0]

#we're interested in Name, age, class and boat(body)
#name can give us gender of the passenger/crew
#there are several special characters in the columns that need fixing
#Also, Age should be converted to int
#let define a method that takes any string and look for indecipherable characters

def cleanup(value):
    return str(str(value).encode('ascii', errors='replace')).replace("?", " ")

def cleanup2(value):
    return value.encode('ascii', errors='replace').replace("?", " ")

#apply clean to each word in the Name column
data['Name'] = data['Name'].apply(cleanup)
data['Boat [Body]'] = data['Boat [Body]'].apply(cleanup)
data['Age'] = data['Age'].apply(pd.to_numeric, errors='coerce')
data = data[['Name', 'Boat [Body]', 'Class/Dept', 'Age']]

#let's add a few columns to this data set, which represent attributes of the passengers or crew members
#we think reflect what their probability of survival on the titanic might have been

#let's define a method that tells where it is a passenger or crew member
#it's likely that the crew members were involved in helping all the passengers get to safety, so the likelihood of a
#passenger surviving is more than the crew
def checkpass(class_type):
    if "Passenger" in class_type:
        return "Passenger"
    else:
        return "Crew"

data['Crew/Pass'] = data['Class/Dept'].apply(checkpass)

#let's check the class of the ticket
def checkClass(class_type):
    if "Passenger" in class_type:
        return class_type.split(" ")[0]
    else:
        return "Crew"

data['Class'] = data['Class/Dept'].apply(checkClass)

#if the passenger was a child or adult
def checkAdult(age):
    if age >= 18:
        return "Adult"
    else:
        return "Child"

data['Adult/Child'] = data['Age'].apply(checkAdult)
#to find the gender we check the pattern, it is last name, first name so we find the index of comma
def checkGender(name):
    firstname = name[name.index(",")+2:]    #Extract the firstname
    saluation = firstname.split(" ")[0]

    if saluation in ["Mr", "Master"]:
        return "Male"
    else:
        return "Female"

data['Gender'] = data['Name'].apply(checkGender)

# check if the passenger survived

def checkSurvival(boat):
    boat = boat.replace("b", "")
    boat = boat.replace("'", "")
    if boat.strip()=="" or "[" in boat or "nan" in boat:
        return 0
    else:
        return 1

data['Survival'] = data['Boat [Body]'].apply(checkSurvival) # this can be used later to verify the results


# we need to ensure that the important features are at a higher point in the decision tree

# we can take each column that represents a particular feature, and then summarize the survival rates for different
#values in that column
#we can start with the crew or passenger column and summarize it using the group by method

#survivalSum = data.groupby(['Crew/Pass'])['Survival'].sum()
#count = data.groupby(['Crew/Pass'])['Survival'].count()

#survivalRate = survivalSum * 100/count
#print(survivalRate)
#Crew         13.586957
#Passenger    35.798817
#so, there is 13% chance that a crew member survived while a 35% chance that a passenger survived
#passenger has a greater survival rate

#do note, we want the survival rate in each category to be as different as possible
# higher the difference, more important is the feature for classification

def compare(group,data):
    survivalSum = data.groupby([group])['Survival'].sum()
    count = data.groupby([group])['Survival'].count()
    survivalRate = survivalSum * 100 / count
    return survivalRate

#testClass = compare('Class',data)
#print(testClass)

#Class
#1st     57.428571
#2nd     37.883959
#3rd     24.259520
#Crew    13.586957
#Name: Survival, dtype: float64

#there's good difference in this feature and hence is important

testGender = compare('Gender',data)
#print(testGender)

#Gender
#Female    59.067358
#Male      15.556739
#Name: Survival, dtype: float64

#Again, a good feature

testAge = compare('Adult/Child',data)

#print(testAge)

#Adult/Child
#Adult    25.078370
#Child    33.183857
#Name: Survival, dtype: float64

#not much difference here

# if we compare all 3, gender seems to be the most important indicator, followed by Class and age

#Next step we'll build the DT with our training data which has features corresponding to each person and label
#saying whether they survived or not, and pass it into a machine-learning algorithm

# this is the training phase. Here, we'll take only those columns that can be fed to the algorithm
trainingData = data[["Age", "Crew/Pass", "Class", "Adult/Child", "Gender","Survival"]]
#print(trainingData.head())
#all these features are categorical variable, they can take values from a given specific set
# such categorical variable need to be converted to numeric value before feeding it to algorithm e.g. Male/female 1/0

def carToNum(series):
    series = series.astype('category') # so pandas know this categorical variable
    return series.cat.codes

catData = trainingData[["Age","Crew/Pass", "Class", "Adult/Child", "Gender","Survival"]].apply(carToNum)
trainingData = catData[["Age","Crew/Pass", "Class", "Adult/Child", "Gender","Survival"]]

# we need to remove any rows that has missing data
trainingData = trainingData.dropna()
#print(len(trainingData))

#we'll split the data into training and test sets
from sklearn.model_selection import train_test_split
train, test = train_test_split(trainingData, test_size = 0.2) # training will 80% while test 20%

#print(train.head())

#Now let's use the algorithm
#from sklearn.tree import DecisionTreeClassifier
#clf = DecisionTreeClassifier()
#clf = clf.fit(train[["Age","Crew/Pass", "Class", "Adult/Child", "Gender"]], train["Survival"])

#print(clf)

#Visualize the data
#numeric score of importance of features
#print(clf.feature_importances_)
#[0.41213783 0.02766265 0.17859231 0.00163276 0.37997444]
#all these add to 1 but higher the score with this array, more important the feature is
#So, gender is most important and so on

#from sklearn import tree
#with open("titanic.dot", "w") as f:
#    f = tree.export_graphviz(clf, feature_names=["Age","Crew/Pass", "Class", "Adult/Child", "Gender"], out_file=f)

# the generated DT seems to big and complex
# we need to control the complexity
# we can control the property max_leaf_nodes
#from sklearn.tree import DecisionTreeClassifier
#clf = DecisionTreeClassifier(max_leaf_nodes=20)
#clf = clf.fit(train[["Age","Crew/Pass", "Class", "Adult/Child", "Gender"]], train["Survival"])

#from sklearn import tree
#with open("titanic.dot", "w") as f:
#    f = tree.export_graphviz(clf, feature_names=["Age","Crew/Pass", "Class", "Adult/Child", "Gender"], out_file=f)

#we'll modify some parameter
#class_weight -> if some parameter needs to be given more importance than others
#criteion -> which methodology to measure homogeneity within the substeps that are formed after breaking up of the data
#based on some attribute. This can be 'gini' impurity
#max_depth -> max distance from root node to any leaf node
#max_features -> tree should accept
#min_impurity_split specifies what should be the minimum percentage impurity is subset for splitting it further,
#let's say in a subset 95% survived and 5% did not, then the subset has 5% impurity
#if that 5% is more than min_impurity_split, then the subset will ne split further
#min_samples_leaf represents the minimum number of data points that should be present in a subset at a leaf node
#min_samples_split -> minimum data points in a subset to allow further splitting
# min_weight_fraction_leaf -> same like min_sample_leaf, here fraction mentioned

#let's see how to measure accuracy, and various parameters affect accuracy
#we'll use the test data set in checking how accurately it predicts the results
#predict method will return a series with predicted labels in the test data set
#and we'll compare this with the actual label
#predictions = clf.predict(test[["Age","Crew/Pass", "Class", "Adult/Child", "Gender"]])

#print(predictions)
#from sklearn.metrics import accuracy_score
#accuracy = accuracy_score(test["Survival"], predictions)
#print(accuracy)

#0.7784552845528455, this accuracy score is specific to the test data set

#let's vary parameters and see if accuracy improves
# Just by adding more nodes or making it more complex raises accuracy
#infact it reduces, this is known as Over fitting
#Now let's change the max_leaf_nodes to 5

#from sklearn.tree import DecisionTreeClassifier
#clf = DecisionTreeClassifier(max_leaf_nodes=5)
#clf = clf.fit(train[["Age","Crew/Pass", "Class", "Adult/Child", "Gender"]], train["Survival"])

#from sklearn import tree
#with open("titanic.dot", "w") as f:
#    f = tree.export_graphviz(clf, feature_names=["Age","Crew/Pass", "Class", "Adult/Child", "Gender"], out_file=f)

#predictions = clf.predict(test[["Age","Crew/Pass", "Class", "Adult/Child", "Gender"]])

#print(predictions)
from sklearn.metrics import accuracy_score
#accuracy = accuracy_score(test["Survival"], predictions)
#print(accuracy)

#0.7987804878048781, nothing much even though it is simple, this is under fitting

#from sklearn.tree import DecisionTreeClassifier
#clf = DecisionTreeClassifier(max_leaf_nodes=15)
#clf = clf.fit(train[["Age","Crew/Pass", "Class", "Adult/Child", "Gender"]], train["Survival"])

#from sklearn import tree
#with open("titanic.dot", "w") as f:
#    f = tree.export_graphviz(clf, feature_names=["Age","Crew/Pass", "Class", "Adult/Child", "Gender"], out_file=f)

#predictions = clf.predict(test[["Age","Crew/Pass", "Class", "Adult/Child", "Gender"]])

#print(predictions)
#from sklearn.metrics import accuracy_score
#accuracy = accuracy_score(test["Survival"], predictions)
#print(accuracy)

#0.8008130081300813 here, accuracy has gone up to 80%

#we'll use the Ensemble Random Forest classifier DT
#from sklearn.ensemble import RandomForestClassifier
#clf = RandomForestClassifier()

#print(train.head())
#print(clf)

#RandomForestClassifier(bootstrap=True, class_weight=None, criterion='gini',
#            max_depth=None, max_features='auto', max_leaf_nodes=None,
#            min_impurity_decrease=0.0, min_impurity_split=None,
#            min_samples_leaf=1, min_samples_split=2,
#            min_weight_fraction_leaf=0.0, n_estimators=10, n_jobs=1,
#            oob_score=False, random_state=None, verbose=0,
#            warm_start=False)

#n_estimators, this parameter is important here. By default 10 DTs will be built using bagging and random subspace
#All 10 will be given equal vote in the final result and the label with majority

#let's check the accuracy by applying some test data
#def checkAccuracy(clf):
#    clf = clf.fit(train[["Age","Crew/Pass", "Class", "Adult/Child", "Gender"]], train["Survival"])
#    predictions = clf.predict(test[["Age", "Crew/Pass", "Class", "Adult/Child", "Gender"]])
#    return accuracy_score(test["Survival"], predictions)

#accuracy = checkAccuracy(clf)
#print(accuracy)

#0.7804878048780488

#Gradient Boosted Trees
from xgboost.sklearn import XGBClassifier
clf = XGBClassifier()

def checkAccuracy(clf):
    clf = clf.fit(train[["Age","Crew/Pass", "Class", "Adult/Child", "Gender"]], train["Survival"])
    predictions = clf.predict(test[["Age", "Crew/Pass", "Class", "Adult/Child", "Gender"]])
    return accuracy_score(test["Survival"], predictions)

accuracy = checkAccuracy(clf)
print(accuracy)

#0.8292682926829268

#performance can further be improved by trying multiple combinations of parameters
#hyperopt is one such package that helps find this optimally
from hyperopt import fmin, tpe, hp, STATUS_OK, Trials

# we need to define a dictionary that let's us specify the range in the parameter to want to search
space = {
    'n_estimators': hp.quniform('n_estimators', 100, 1000, 1),
    'learning_rate': hp.quniform('learning_rate', 0.025, 0.5, 0.025),
    'max_depth': hp.quniform('max_depth', 1, 13, 1),
    'min_child_weight': hp.quniform('min_child_weight', 1, 6, 1),
    'subsample': hp.quniform('subsample', 0.5, 1, 0.05),
    'gamma': hp.quniform('gamma', 0.5, 1, 0.05),
    'colsample_bytree': hp.quniform('colsample_bytree', 0.5, 1, 0.05),
    'nthread': 6,
    'silent': 1

}

#nthread used for parallelization
#every number has equal probability of being picked
#next, we need a function which represents the score that'll be calculated in each trial
#function evaluated and minimized with each set of parameters
def score(params):
    params['n_estimators'] = int(params['n_estimators'])    # we need to ensure this is an integer
    params['max_depth'] = int(params['max_depth'])
    clf = XGBClassifier(**params)                           # here we pass the params to classifier
    return {'loss': 1 - checkAccuracy(clf), 'status':STATUS_OK}
#you should always return a score that you want minimized, so instead of returning the accuracy itself, we
#return the percentage of values that are misclassified in the test data set
#so the list of parameters we'll get finally will be the parameters that minimize the misclassification rate

trials = Trials()
best = fmin(score, space, algo=tpe.suggest,trials=trials,max_evals=250)

print(best)
#{'min_child_weight': 1.0, 'gamma': 0.55, 'subsample': 1.0, 'max_depth': 1.0, 'n_estimators': 188.0, 'learning_rate': 0.2, 'colsample_bytree': 0.55}

accu = 1 - score(best)['loss']
print(accu)

#0.8252032520325203