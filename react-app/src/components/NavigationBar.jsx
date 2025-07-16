import { useState } from "react";
import { faBars, faSignIn, faSignOut } from "@fortawesome/free-solid-svg-icons";
import LayeredIcons from "./LayeredIcons";
import {
  NavBar,
  NavBarLeft,
  NavBarRight,
  NavBarRightDesktop,
  NavBarLinkList,
  NavBarLink,
  NavBarDropdownBox,
  LoginButton,
  LoginContainer,
  RightMobileIcon,
  NavBarMobileMenu,
  NavBarMobileLinks,
} from "../styled/NavigationBar";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { useNavigate } from "react-router-dom";

export default function NavigationBar() {
  const username = localStorage.getItem("username");
  const [showLogout, setShowLogout] = useState(false);
  const navigate = useNavigate();

  function handleLogout() {
    if (username === null) {
      navigate("/profile", { replace: true });
    } else {
      localStorage.clear();
      window.location.reload();
    }
  }

  return (
    <NavBar>
      <NavBarLeft>
        <LayeredIcons />
        <p>Reality Fights</p>
      </NavBarLeft>
      <NavBarRight>
        <NavBarRightDesktop>
          <NavBarLinkList>
            <li>
              <NavBarLink
                id="home"
                to="/"
                style={({ isActive }) => {
                  return {
                    color: isActive ? "#ffba86" : "#83c0c1",
                  };
                }}
              >
                Home
              </NavBarLink>
            </li>
            <li>
              <NavBarLink
                id="search"
                to="/search"
                style={({ isActive }) => {
                  return {
                    color: isActive ? "#ffba86" : "#83c0c1",
                  };
                }}
              >
                Search
              </NavBarLink>
            </li>
            <li>
              <NavBarLink
                id="profile"
                to="/profile"
                style={({ isActive }) => {
                  return {
                    color: isActive ? "#ffba86" : "#83c0c1",
                  };
                }}
              >
                Profile
              </NavBarLink>
            </li>
            <li>
              <LoginButton
                onMouseEnter={() => setShowLogout(true)}
                onMouseLeave={() => setShowLogout(false)}
                onClick={handleLogout}
              >
                {username === null ? (
                  <FontAwesomeIcon icon={faSignIn} />
                ) : (
                  <FontAwesomeIcon icon={faSignOut} />
                )}
                {showLogout && (
                  <LoginContainer>
                    {username === null ? (
                      <h4>Click to Login</h4>
                    ) : (
                      <h4>Click to Confirm Logout</h4>
                    )}
                  </LoginContainer>
                )}
              </LoginButton>
            </li>
          </NavBarLinkList>
        </NavBarRightDesktop>
        <NavBarDropdownBox>
          <RightMobileIcon icon={faBars} />
          <NavBarMobileMenu>
            <NavBarMobileLinks
              to="/"
              style={({ isActive }) => {
                return {
                  display: isActive ? "none" : "inherit",
                };
              }}
            >
              Home
            </NavBarMobileLinks>
            <NavBarMobileLinks
              to="/search"
              style={({ isActive }) => {
                return {
                  display: isActive ? "none" : "inherit",
                };
              }}
            >
              Search
            </NavBarMobileLinks>
            <NavBarMobileLinks
              to="/profile"
              style={({ isActive }) => {
                return {
                  display: isActive ? "none" : "inherit",
                };
              }}
            >
              Profile
            </NavBarMobileLinks>
          </NavBarMobileMenu>
        </NavBarDropdownBox>
      </NavBarRight>
    </NavBar>
  );
}
