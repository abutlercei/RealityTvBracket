// Styled components for Navigation Bar component
import styled from "styled-components";
import { Link } from "react-router-dom";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
// import { faBars } from "fortawesome/free-solid-svg-icons";

export const NavBar = styled.nav`
  margin-top: 0;
  margin-left: 0;
  width: calc(100%-4rem);
  height: 5rem;
  display: flex;
  justify-content: space-between;
  align-items: center;
  color: #83c0c1;
  background-color: #6c22a6;
  font-size: 1.5rem;
  box-shadow: 5px 5px 2px;
`;

export const NavBarLeft = styled.div`
  justify-self: flex-start;
  margin-left: 3rem;
  display: flex;
  justify-content: center;
  align-items: center;

  // Media Query for Mobile Navigation
  @media (max-width: 600px) {
    margin-left: 1rem;
  }
`;

export const NavBarRight = styled.div`
  justify-self: flex-end;
  margin-right: 3rem;
`;

export const NavBarRightDesktop = styled.div`
  // Media Query to only display on larger screens
  @media (max-width: 600px) {
    display: none;
  }
`;

export const NavBarLinkList = styled.ul`
  list-style: none;
  display: flex;
  gap: 2rem;
`;

export const NavBarLink = styled(Link)`
  &:link,
  &:visited {
    text-decoration: none;
    color: #83c0c1;
  }

  &:hover,
  &:active {
    color: #ffba86;
  }
`;

export const RightMobileIcon = styled(FontAwesomeIcon)`
  display: none;
  justify-self: flex-end;
  margin-right: 3rem;

  // Media Query to show on mobile devices
  @media (max-width: 600px) {
    display: flex;
    margin-right: 1rem;
  }
`;

export const NavBarMobileMenu = styled.div`
  display: none;
  position: absolute;
  border-radius: 0.25rem;
  background-color: #83c0c1;
  outline solid #6c22a6 2px;
  box-shadow: 5px 5px 3px #6c22ac58;
  margin-left: -2rem;
  padding: 0.5rem;
`;

export const NavBarDropdownBox = styled.div`
  // Media Query to display only in mobile when hovering
  @media (max-width: 600px) {
    &:hover ${NavBarMobileMenu} {
      display: flex;
      flex-direction: column;
    }
  }
`;

export const NavBarMobileLinks = styled(Link)`
  &:link,
  &:visited,
  &:active {
    color: #6c22a6;
  }

  &:hover {
    background-color: hotpink;
  }
`;
