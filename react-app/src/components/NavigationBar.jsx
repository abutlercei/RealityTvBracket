import { faBars } from "@fortawesome/free-solid-svg-icons";
import LayeredIcons from "./LayeredIcons";
import {
  NavBar,
  NavBarLeft,
  NavBarRight,
  NavBarRightDesktop,
  NavBarLinkList,
  NavBarLink,
  NavBarDropdownBox,
  RightMobileIcon,
  NavBarMobileMenu,
  NavBarMobileLinks,
} from "../styled/NavigationBar";

export default function NavigationBar() {
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
