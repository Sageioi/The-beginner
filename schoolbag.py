#Project: Predict Student exam scores based on how many hours they studied
import numpy as np
import matplotlib.pyplot as plt
import pandas as pd
from sklearn.linear_model import LinearRegression
from sklearn.metrics import mean_squared_error, r2_score, mean_absolute_error
import streamlit as st

st.title('Simple Linear Regression')
hours_studied = [1.5, 2, 2.5, 3, 3.5, 4, 4.5, 5]
exam_score = [35, 40, 50, 55, 60, 65, 70, 75]

data = {"hours": hours_studied, "score": exam_score}
st.dataframe(data)
df = pd.DataFrame(data)

x = np.arange(len(hours_studied)).reshape(-1, 1)
y = np.array(exam_score)

model = LinearRegression()
model.fit(x, y)
y_pred = model.predict(x)

fig,ax = plt.subplots(figsize=(5, 4))
ax.scatter(x, y, label="Exam score", color="red")
ax.plot(x, y_pred, label="Prediction using linear regression")
ax.set_title("Prediction of exam score based on studying hours ")
ax.set_xlabel("Hours of study")
ax.set_ylabel("Exam scores")
ax.legend()
ax.grid(True)
st.pyplot(fig)

st.write(f"Accuracy based on R2 score: {r2_score(y, y_pred):.3f}")
st.write(f"Accuracy based on Mean squared error: {mean_squared_error(y, y_pred):.3f}")
st.write(f"Accuracy based on Mean absolute error : {mean_absolute_error(y, y_pred):.3f}")
