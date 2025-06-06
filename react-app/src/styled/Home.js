// Style objects for Home component
import styled from "styled-components";

export const PageContainer = styled.div`
  margin-left: 3rem;
  margin-right: 3rem;
  display: flex;
  align-items: center;
  justify-content: center;

  // Media query for page container
  @media (max-width: 600px) {
    margin-left: 1rem;
    margin-right: 1rem;
  }
`;
