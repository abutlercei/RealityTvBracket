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
              <NavBarLink to="/">Home</NavBarLink>
            </li>
            <li>
              <NavBarLink to="/search">Search</NavBarLink>
            </li>
            <li>
              <NavBarLink to="/profile">Profile</NavBarLink>
            </li>
          </NavBarLinkList>
        </NavBarRightDesktop>
        <NavBarDropdownBox>
          <RightMobileIcon icon={faBars} />
          <NavBarMobileMenu>
            <NavBarMobileLinks to="/">Home</NavBarMobileLinks>
            <NavBarMobileLinks to="/search">Search</NavBarMobileLinks>
            <NavBarMobileLinks to="/profile">Profile</NavBarMobileLinks>
          </NavBarMobileMenu>
        </NavBarDropdownBox>
      </NavBarRight>
    </NavBar>
  );
}
