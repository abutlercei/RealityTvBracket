import { useState } from "react";
import { Link } from "react-router-dom";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faBars } from "@fortawesome/free-solid-svg-icons";
import LayeredIcons from "../LayeredIcons/LayeredIcons";
import styles from "./NavigationBar.module.css";

export default function NavigationBar() {
  const [isOpen, setIsOpen] = useState(false);

  const handleClick = () => {
    if (isOpen) {
      alert("Menu is open");
    } else {
      alert("Menu is closed");
    }
    setIsOpen((prevIsOpen) => !prevIsOpen);
  };

  return (
    <nav className={styles.navbar}>
      <div className={styles.navbarLeft}>
        <LayeredIcons />
        <p>Reality Fights</p>
      </div>
      <div className={styles.navbarRightDesktop}>
        <ul className={styles.navbarLinks}>
          <li>
            <Link to="/">Home</Link>
          </li>
          <li>
            <Link to="/search">Search</Link>
          </li>
          <li>
            <Link to="/profile">Profile</Link>
          </li>
        </ul>
      </div>
      <FontAwesomeIcon
        className={styles.navbarRightMobile}
        icon={faBars}
        onClick={handleClick}
      />
      <div className={styles.navbarMobileMenu} style={{ display: "none" }}>
        <ul>
          <li>
            <Link to="/">Home</Link>
          </li>
          <li>
            <Link to="/search">Search</Link>
          </li>
          <li>
            <Link to="/profile">Profile</Link>
          </li>
        </ul>
      </div>
    </nav>
  );
}
