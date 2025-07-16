// Style objects for Home component
import styled from "styled-components";

export const PageContainer = styled.div`
  margin-left: 3rem;
  margin-right: 3rem;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  margin-bottom: 3rem;

  // Media query for page container
  @media (max-width: 600px) {
    margin-left: 1rem;
    margin-right: 1rem;
  }
`;

export const TableContainer = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  width: 100%;
  gap: 3rem;
`;

export const SingleCellRow = styled.th`
  padding: 0.5rem, 1rem;
  text-align: center;
  font-size: larger;
  border: 1px solid #83c0c1;
`;
