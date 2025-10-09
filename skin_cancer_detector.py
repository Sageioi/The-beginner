import streamlit as st
import cv2
import joblib
import numpy as np
from PIL import Image


st.title("Dermatect",width="stretch")
st.header("Detecting Skin Cancer",divider="red",)

st.subheader("""This is a basic project created by RetinAi, a computer vision laboratory. All you just have to do is upload a photo of your skin and it can tell whether you have skin cancer or not. Do well to note that this is no substitute for professional advice.""",divider="red")
upload = st.file_uploader("Upload a Photo",type=["jpg","jpeg","png"])

if upload :
    img_array = []
    st.success("File(s) successfully uploaded. ")
    upload = Image.open(upload)
    image = np.array(upload)
    image = cv2.cvtColor(image, cv2.COLOR_BGR2RGB)
    image = cv2.resize(image,(64,64))
    image = image.flatten()
    img_array.append(image)

    model = joblib.load("dermtect.pkl")
    img_pred = model.predict(img_array)
    if img_pred[0] == 1:
        st.success("You have no symptoms of skin cancer.",icon=":material/check_circle:")
    if img_pred[0] == 0:
        st.warning("You may need to see your doctor.",icon=":material/warning:",)
else :
    st.warning("You have not uploaded any photos.",icon=":material/warning:")


