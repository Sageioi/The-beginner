import streamlit as st
from sklearn.tree import DecisionTreeClassifier

st.title("Credit risk scoring model for Enterprises")
st.subheader("This model can predict nearly accurately the tendency of the user to default on payment of credit")
## A Basic Credit Scoring Model
import pandas as pd
from sklearn.metrics import accuracy_score
## Data source
data = pd.read_csv(r"C:\Users\USER\OneDrive\Desktop\Data for ML\original.csv")

data = {'income':data['income'],'age':data['age'],'loan':data['loan'],'rk_score':data['default']}
data = pd.DataFrame(data)
data.dropna(inplace=True)

x = data[['income','age','loan']]
y = data['rk_score']


model = DecisionTreeClassifier(random_state=42)
model.fit(x,y)

y_pred = model.predict(x)

print(f"Accuracy score is {accuracy_score(y,y_pred)}")

st.subheader("Enter Client Details")

inc_input = st.number_input("Enter client's income",min_value=0, value=1)
age_input = st.number_input("Enter client's age",min_value=0, value=1)
crdt_input = st.number_input("Enter client's loan",min_value=0, value=1)
future_data = pd.DataFrame({'income':[inc_input],'age':[age_input],'loan':[crdt_input]})
future_x = future_data[['income','age','loan']]

future_y = model.predict(future_x)

print(f"Accuracy score is {accuracy_score(future_y,future_y)}")

st.write("Click button to score client.")
button = st.button("Score Client")

if button:
    if future_y == 0:
        st.success("User is not likely to default.")
        st.success(f"User's credibility score is high")
    else :
        st.warning("User is likely to default.")
        st.warning(f"User's credibility score is low")




