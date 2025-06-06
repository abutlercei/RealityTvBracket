import { useState } from "react";
import { faMagnifyingGlass } from "@fortawesome/free-solid-svg-icons";
import Pool from "./Pool";
import { SearchBox, SearchIcon, SearchInput } from "../styled/Search";

export default function Search() {
  const searchDivStyle = {
    display: "flex",
    flexDirection: "column",
  };

  return (
    <div style={searchDivStyle}>
      <SearchBox>
        <SearchIcon icon={faMagnifyingGlass} />
        <SearchInput type="text" placeholder="Search Pools..." />
      </SearchBox>
      <Pool />
    </div>
  );
}
