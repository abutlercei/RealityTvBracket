import styled from "styled-components";

export const IntroductionContainer = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content;
`;

export const FeatureContainer = styled.div`
  width: 100%;
  display: flex;
  flex-direction: row;
  justify-content: center;
  gap: 5%;
`;

export const Feature = styled.div`
  width: 25%;
  min-height: 20rem;
  background-color: rgba(120, 206, 170, 0.6);
  border-radius: 3rem;
`;

export const Circle = styled.div`
  display: flex;
  align-items: center;
  justify-content: center;
  width: 5rem;
  height: 5rem;
  margin: 1rem;
  border-radius: 2.5rem;
  background-color: #6962ad;
  color: #afebd2;
`;

export const FeatureDescription = styled.h2`
  text-align: center;
  padding: 1rem;
`;
