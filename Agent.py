from sklearn.linear_model import LinearRegression
import numpy as np
import matplotlib.pyplot as plt
import pandas as pd

x = [1,2,3,4,5]
y = [2,4,5,4,5]
dataframe = pd.DataFrame({'x':x,'y':y})

x = dataframe[['x']]
y = dataframe['y']

model = LinearRegression()
model.fit(x,y)
y_pred = model.predict(x)

plt.figure(figsize=[5,5])
plt.plot(x,y_pred,label='Linear Regression',color='blue')
plt.scatter(x,y,label='Values',color='red')
plt.title("Linear Regression")
plt.xlabel('x')
plt.ylabel('y')
plt.legend()
plt.grid(True)
plt.show()
print(y_pred[5])



