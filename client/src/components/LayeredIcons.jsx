import React from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faTv, faPiggyBank } from "@fortawesome/free-solid-svg-icons";

export default function LayeredIcons() {
  return (
    <span className="fa-layers fa-fw" style={{ margin: "0 1rem" }}>
      <FontAwesomeIcon icon={faTv} transform="grow-10" />
      <FontAwesomeIcon icon={faPiggyBank} transform="shrink-2 up-2" />
    </span>
  );
}
