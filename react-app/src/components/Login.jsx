import {
  LoginContainer,
  Heading,
  UserForm as Form,
  Input,
  Button,
} from "../styled/Login";
export default function Login(props) {
  function handleSubmit(e) {
    const sumbitData = new FormData(e.target);
    const username = sumbitData.get("login_username");
    const password = sumbitData.get("login_password");
    props.setUsername(username);
    localStorage.setItem("username", username);
  }
  return (
    <LoginContainer>
      <Heading>Login Below</Heading>
      <Form onSubmit={handleSubmit}>
        <label htmlFor="login_username">
          Username:{" "}
          <Input type="text" name="login_username" id="login_username" />
        </label>
        <label htmlFor="login_password">
          Password:{" "}
          <Input type="password" name="login_password" id="login_password" />
        </label>
        <Button type="submit">Login</Button>
      </Form>
    </LoginContainer>
  );
}
