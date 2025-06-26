// Style components for the Pool Table component added to Pool components
import styled from "styled-components";

export const Table = styled.table`
  width: 90%;
  border-collapse: collapse;
  background-color: #6c22a6;
  color: #83c0c1;
`;

export const TableHeader = styled.thead`
  padding: 1rem, 1rem;
  text-align: center;
`;

export const TableCell = styled.th`
  padding: 0.5rem, 1rem;
  text-align: center;
  border: 1px solid #83c0c1;
`;

export const AlternateRow = styled.tr`
  background-color: #6962ad;
`;
