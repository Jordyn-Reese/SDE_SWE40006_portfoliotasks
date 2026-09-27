from flask import Flask
from datetime import datetime

#create a funcion call to the app 
app = Flask(__name__)

#app operations go here
@app.route("/")
@app.route("/build")
def build():
    date = datetime.now()
    true_date = date.strftime("%d-%m-%Y")
    true_time = date.strftime("%I:%M:%S %p")
    statement = (f"The current date is: {true_date} <br> The current time is: {true_time}")
    # ("The current date is: " + str(true_date) + "\n" + "The current time is: " + str(true_time)) 
    return statement

#if main is running, run the app
if __name__ == "__main__":
    print("Main has been called")
    # default port is 5000 or 127.0.0.1 -- changed port to 8080 and host to 0.0.0.0 for local host
    app.run(debug=True, host = "0.0.0.0", port = 8080)