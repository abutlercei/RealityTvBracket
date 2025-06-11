// Styled components for Profile components
import styled from "styled-components";

export const ProfileTitle = styled.h1`
  text-align: center;
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
