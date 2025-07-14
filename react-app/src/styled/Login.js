// Style objects for Login component
import styled from "styled-components";

export const LoginContainer = styled.div`
  width: 50%;
  max-height: 70%;
  padding: 3rem;
  justify-self: center;
  align-self: center;
  display: flex;
  flex-direction: column;
  background-color: rgba(131, 192, 193, 0.51);
  box-shadow: 3px 3px 2px #83c0c1;
`;

export const Heading = styled.h1`
  text-align: center;
`;

export const UserForm = styled.form`
  display: flex;
  flex-direction: column;
  align-items: center;
  gap: 1rem;
`;

export const Input = styled.input`
  margin-left: 1rem;
  padding: 0.5rem;
  border-radius: 5px;
  background-color: #6c22a6;
  color: #83c0c1;
  box-shadow: 3px 3px #83c0c1;

  &::placeholder {
    color: #83c0c1;
  }
`;

export const Button = styled.button`
  background-color: #6c22a6;
  color: #83c0c1;
  font-size: 1rem;
  font-weight: bolder;
  border-radius: 5px;
  padding: 1rem;
  margin-top: 1rem;
`;
