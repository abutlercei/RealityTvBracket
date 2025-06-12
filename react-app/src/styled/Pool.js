// Styled components for Pool component
import styled from "styled-components";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

export const BackArrow = styled(FontAwesomeIcon)`
  float: left;
  font-size: 3rem;
  align-self: flex-start;
  margin: 2rem;
`;

export const PageContainer = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  margin-bottom: 1rem;
`;

export const PoolName = styled.h1`
  font-weight: 900;

  // Media Query to fix mobile title formatting
  @media (max-width: 600px) {
    width: 90%;
    text-align: center;
  }
`;

export const PageContent = styled.div`
  display: flex;
  justify-content: center;
  gap: 1rem;
  width: 90%;

  // Media Query to flip direction of sub-containers
  @media (max-width: 600px) {
    flex-direction: column;
  }
`;

export const ContentBox = styled.div`
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  width: 45%;

  // Media Query to format content on smaller screens
  @media (max-width: 600px) {
    width: 80%;
    align-self: center;
  }
`;

export const PoolSource = styled.h2`
  font-weight: 900;

  // Media Query to fix mobile formatting
  @media (max-width: 600px) {
    width: 90%;
    text-align: center;
  }
`;

export const PoolHost = styled.h3`
  margin-top: -1rem;

  // Media Query to fix mobile formatting
  @media (max-width: 600px) {
    width: 90%;
    text-align: center;
  }
`;

export const PageLink = styled.a`
  &:link,
  &:visited,
  &:active,
  &:hover {
    color: hotpink;
    text-decoration-line: underline;
  }
`;

export const PoolBio = styled.p`
  width: 60%;
  padding: 1rem;
  margin-top: -1rem;
`;

export const JoinButton = styled.button`
  background-color: #6c22a6;
  color: #83c0c1;
  font-size: 1rem;
  font-weight: bolder;
  border-radius: 5px;
  padding: 1rem;
  margin-top: 1rem;
`;

export const JoinedDiv = styled(JoinButton)`
  background-color: #2e8b57;
  color: white;
  box-shadow: 2px 2px 1px white;
`;
