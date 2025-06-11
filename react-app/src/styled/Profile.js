// Styled components for Profile components
import styled from "styled-components";

export const ProfileTitle = styled.h1`
  text-align: center;
  align-self: center;
  justify-self: center;
  width: 100%;
  font-weight: 500;
`;

export const ProfileHeading = styled.h2`
  text-align: center;
`;

export const Container = styled.div`
  display: flex;
  flex-direction: row;
  gap: 3rem;

  @media (max-width: 600px) {
    flex-direction: column;
  }
`;

export const Column = styled.div`
  width: 40%;
  display: flex;
  flex-direction: column;
  align-items: center;
  padding: 2rem;
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
