// Styled components for Search tab
import styled from "styled-components";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

export const SearchBox = styled.div`
  padding: 1rem;
  margin-top: 1rem;
  border-radius: 5px;
  border: 1px solid black;
  width: 30%;
  align-self: center;
  display: flex;
  justify-content: start;
  align-items: center;
  gap: 0.5rem;
  boxshadow: 0 2px 4px black;
`;

export const SearchIcon = styled(FontAwesomeIcon)`
  height: 1rem;
  width: 1rem;
`;

export const SearchInput = styled.input`
  width: 100%;
  border: none;
  zindex: 1;
  background-color: transparent;

  &:focus {
    outline: none;
  }
`;
