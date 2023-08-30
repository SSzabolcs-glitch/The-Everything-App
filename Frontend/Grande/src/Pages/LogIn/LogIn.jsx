import { useState, useContext } from "react";
//import { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import CustomerForm from "../../Components/CustomerForm/CustomerForm.jsx";
import { UserContext } from "../../main";
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
  const context = useContext(UserContext); //connect to UserContext

  const handleLogIn = (user) => {
    setLoading(true);
    loginUser(user)
      .then((data) => {
        setLoading(false);
        context.setUser(data); //set the user in the context
        navigate("/");
      })
      .catch((error) => {
        console.error("Login error:", error);
        setLoading(false);
      });
  };

  if (context.user) {
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
