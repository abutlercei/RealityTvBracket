import { useState } from "react";
import {
  LoginContainer,
  Heading,
  UserForm as Form,
  Input,
  Button,
  ErrorMessage,
} from "../styled/Login";
import { findUser } from "../services/userService";

export default function Login(props) {
  const [errors, setErrors] = useState({});

  async function handleSubmit(e) {
    e.preventDefault();
    const sumbitData = new FormData(e.target);
    const username = sumbitData.get("login_username");

    let isValid = await validateForm(sumbitData);
    if (isValid) {
      props.setUsername(username);
      localStorage.setItem("username", username);
      window.history.replaceState(null, "", "http://localhost:5254/profile");
    }
  }

  async function validateForm(form) {
    let newErrors = {};
    let isValidForm = true;

    if (form.get("login_username").trim() == "") {
      newErrors.username = "Username is required.";
      isValidForm = false;
    }

    if (form.get("login_password").trim() == "") {
      newErrors.password = "Password is required.";
      isValidForm = false;
    }

    if (isValidForm) {
      let isValidCredentials = await findUser(form);
      if (!isValidCredentials) {
        newErrors.credentials =
          "Credentials not found. Please check username and password are correct.";
        isValidForm = false;
      }
    }

    setErrors(newErrors);
    return isValidForm;
  }

  return (
    <LoginContainer>
      <Heading>Login Below</Heading>
      <Form onSubmit={handleSubmit}>
        {errors.username && <ErrorMessage>{errors.username}</ErrorMessage>}
        <label htmlFor="login_username">
          Username:{" "}
          <Input type="text" name="login_username" id="login_username" />
        </label>
        {errors.password && <ErrorMessage>{errors.password}</ErrorMessage>}
        <label htmlFor="login_password">
          Password:{" "}
          <Input type="password" name="login_password" id="login_password" />
        </label>
        {errors.credentials && (
          <ErrorMessage>{errors.credentials}</ErrorMessage>
        )}
        <Button type="submit">Login</Button>
      </Form>
    </LoginContainer>
  );
}
