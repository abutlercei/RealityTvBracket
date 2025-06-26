// Styled components for Search tab
import styled from "styled-components";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

export const SearchContainer = styled.div`
  display: flex;
  flex-direction: column;
`;

export const SearchBox = styled.div`
  padding: 1rem;
  margin: 1rem;
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

export const PoolList = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  gap: 1rem;
`;

export const PoolItem = styled.div`
  width: 60%;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  background-color: #6c22a6;
  color: #83c0c1;
  border-radius: 1rem;
  box-shadow: 5px 5px 2px #6962ad;
`;

export const PoolItemContent = styled.div`
  width: 80%;
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  margin-top: -2rem;
`;

export const PoolIconInfo = styled.div`
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: center;
`;

export const ItemIcon = styled(FontAwesomeIcon)`
  margin-right: 5px;
  font-size: 1rem;
`;
