import { useState, useContext } from "react";
//import { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import CustomerForm from "../../Components/CustomerForm/CustomerForm.jsx";
import { TokenContext } from "../../main";
import "./LogIn.css";

const loginUser = (user) => {
  console.log(user);
  return fetch("https://localhost:7037/Auth/Login", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(user),
  }).then((res) => res.json());
};

const LogIn = () => {
  const navigate = useNavigate();
  const [loading, setLoading] = useState(false);
  //const [token, setToken] = useState("");
  const context = useContext(TokenContext); //connect to TokenContext

  const handleLogIn = (user) => {
    setLoading(true);
    loginUser(user)
      .then((data) => {
        setLoading(false);
        //setToken(data.token);
        context.setToken(data.token); //set the token in the context
        navigate("/");
      })
      .catch((error) => {
        console.error("Login error:", error);
        setLoading(false);
      });
  };

  if (context.token) {
    return <p>You are already logged in.</p>;
  }

  return (
    <CustomerForm
      onCancel={() => navigate("/")}
      onSave={handleLogIn}
      disabled={loading}
      isRegister={false}
    />
  );
};

export default LogIn;
