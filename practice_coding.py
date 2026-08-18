## Banking System
import uuid
import time
import bcrypt
import secrets 
from typing import Literal


account_type : list[str] = ["Deposit","Savings","Investment"]
user_database = {}
class User():
    def __init__(self, username: str, payment_pin: int, password: str, user_id, account_number : int, bank_balance: int = 5000) -> None :
        self.user_id = user_id
        self.password = password
        self.username = username
        self.bank_balance = bank_balance
        self.account_number = account_number
        self.payment_pin = payment_pin

    
    def register(self,type_of_account : str)-> str:
        user_database.update({
            
             self.user_id:
                    {"Name of User": self.username,
                    "User Password": bcrypt.hashpw(self.password.encode('utf-8'),bcrypt.gensalt(rounds=15,prefix=b"2a")) ## Implement encryption of password
                    ,"Type of account": type_of_account,
                    "Bank Balance": self.bank_balance,
                    "Payment Pin": self.payment_pin,
                    "Account Number": self.account_number},
        })
        return "Welcome to Tega Bank"

    def check_password(self,provided_password : str, exception:str):
       for id,details in user_database.items():
          stored_password = details["User Password"]
          status  = bcrypt.checkpw(provided_password.encode('utf-8'),stored_password) 
          if status:
             return status
          else :
             return exception
          

    def logout(self,password:str ,user_id) -> str | Literal[True] | None:
          result  =self.check_password(password,"User Not Found")
          if result:
              if user_database is not None:
                 del user_database[user_id]
                 return "We will miss you"
          else :
             return result

    
    def login(self,password:str) -> str | Literal[True] | None:
          result  =self.check_password(password,"Invalid Details")
          if result:
               return "You are successfully logged in"
          else :
                return result
          
class Bank(User):
    def __init__(self, username: str, payment_pin: int, password: str, user_id, account_number: int, bank_balance: int = 5000) -> None:
        super().__init__(username, payment_pin, password, user_id, account_number, bank_balance)

    def process_payment(self,amount_payable : int, payment_pin: int):
            message : str = ""
            for id,details in user_database.items():
                if payment_pin == details["Payment Pin"] :
                    if details["Bank Balance"] > amount_payable :
                      details["Bank Balance"] -= amount_payable
                      message = f"Payment of {amount_payable} Successful"
                    else :
                      message = "Insufficient funds"
                    return message

    def disclose_account_type(self,account_number):
        for details in user_database.values():
            if account_number == details["Account Number"]:
                for id, value in details.items():
                    if id == "User Password":
                        continue
                    print(f"{id}:{value}")
            else :
                break

    def switch_tier(self, account_number, desired_tier: str, tier_payment : int, bank_balance):
        for details in user_database.values():
            if account_number == details["Account Number"] and bank_balance > tier_payment:
                if details["Type of account"] != desired_tier:
                    bank_balance -= tier_payment
                    details["Type of account"] = desired_tier
                    return f"Switch to the {desired_tier} type of account was successful"
                else: 
                    return f"{desired_tier} is your present tier"

                
              


if __name__ == "__main__":
        user_status : bool = False
        print("Loading.....")
        print("Welcome to Tega Bank\nLet's get you started")
        user_name = input("What's your name : ")
        password = input("Your password ? : ")
        print("Processing...")
        print("Your bank balance currently is 5000. Please finance it.")
        while True:
            payment_pin = int(input("Create a payment pin : ")) 
            if type(payment_pin) != int:
                raise ValueError
            else :
                break
        account_number = secrets.randbits(30)
        user_id = uuid.uuid4()
        new_user = User(user_name,payment_pin,password,user_id,account_number)
        banking_system = Bank(user_name,payment_pin,password,user_id,account_number)
        print(new_user.register(account_type[0]))
        while True:
            print("Options available for you : Log out [1], Log in [2] , Process payment [3], Switch tier [4], Disclose account [5]")
            choice = int(input("Your choice : "))
            if type(choice) != int:
                raise ValueError
            else :
                if choice == 1 and user_status == True:
                    password = input("Your password ? : ")
                    message = new_user.logout(password,new_user.user_id)
                    user_status = False
                    print(message)
                elif choice == 2:
                    password = input("Your password ? : ")
                    message = new_user.login(password)
                    user_status = True
                    print(message)
                elif choice == 3 and user_status == True:
                    while True:
                        payment_pin = int(input("Input your payment pin : ")) 
                        break
                    while True:
                        amount = int(input("Input your amount : ")) 
                        break
                    message = banking_system.process_payment(amount,payment_pin)
                    print(message)
                elif choice == 4 and user_status == True:
                    while True:
                        choice = input("Input your tier : ")
                        if choice == account_type[0]:
                            print(banking_system.switch_tier(new_user.account_number,account_type[0],100,new_user.bank_balance))
                            break
                        elif choice == account_type[1]:
                            print(banking_system.switch_tier(new_user.account_number,account_type[1],500,new_user.bank_balance))
                            break
                        elif choice == account_type[2]:
                            print(banking_system.switch_tier(new_user.account_number,account_type[2],1500,new_user.bank_balance))
                            break
                        else:
                            print("Try again")
                        
                elif choice == 5 and user_status == True:
                    print(banking_system.disclose_account_type(new_user.account_number))

                else : 
                    print("Log in first")
                
            
            


            