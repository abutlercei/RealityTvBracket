import { useState, useEffect } from "react";
import { fetchData } from "../services/apiService";
import { faMagnifyingGlass } from "@fortawesome/free-solid-svg-icons";
import Pool from "./Pool";
import {
  SearchContainer,
  SearchBox,
  SearchIcon,
  SearchInput,
  PoolList,
  PoolItem,
  PoolItemContent,
} from "../styled/Search";

export default function Search() {
  const [pools, setPools] = useState([]);
  const [poolKeys, setPoolKeys] = useState([]);

  // Loads all pools upon screen reload
  useEffect(() => {
    async function getPools() {
      try {
        const response = await fetchData("getAllPools", "none");
        if (response) {
          Array.from(response).forEach((pool) => {
            if (!poolKeys.includes(pool.Name)) {
              setPools((prevPools) => [
                ...prevPools,
                <PoolItem
                  key={pool.Name}
                  onClick={handleClickPoolCell}
                  buttondata={pool.Name}
                >
                  <h2 style={{ color: "hotpink" }} buttondata={pool.Name}>
                    {pool.Name}
                  </h2>
                  <PoolItemContent buttondata={pool.Name}>
                    <h3 buttondata={pool.Name}>{pool.SourceName}</h3>
                    <h3 buttondata={pool.Name}>{pool.Host}</h3>
                  </PoolItemContent>
                </PoolItem>,
              ]);

              setPoolKeys((prevKeys) => [...prevKeys, pool.Name]);
            }
          });
        }
      } catch {
        console.error("Pools failed to load");
      }
    }
    getPools();
  }, []);

  async function handleClickPoolCell(e) {
    console.log(e.target.getAttribute("buttondata"));
    // Call database to return pool members
    // Send PoolInfo to pool component
  }

  return (
    <SearchContainer>
      <SearchBox>
        <SearchIcon icon={faMagnifyingGlass} />
        <SearchInput type="text" placeholder="Search Pools..." />
      </SearchBox>
      <PoolList>{pools}</PoolList>
      {/* <Pool /> */}
    </SearchContainer>
  );
}
