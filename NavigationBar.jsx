// import { useState } from "react";
import { Link } from "react-router-dom";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faBars } from "@fortawesome/free-solid-svg-icons";
import LayeredIcons from "../LayeredIcons/LayeredIcons";
import styles from "./NavigationBar.module.css";

export default function NavigationBar() {
  return (
    <nav className={styles.navbar}>
      <div className={styles.navbarLeft}>
        <LayeredIcons />
        <p>Reality Fights</p>
      </div>
      <div className={styles.navbarRight}>
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
        <div className={styles.navbarDropdownBox}>
          <FontAwesomeIcon
            className={styles.navbarRightMobile}
            icon={faBars}
          />
          <div className={styles.navbarMobileMenu}>
            <Link to="/">Home</Link>
            <Link to="/search">Search</Link>
            <Link to="/profile">Profile</Link>
          </div>
        </div>
      </div>
    </nav>
  );
}
