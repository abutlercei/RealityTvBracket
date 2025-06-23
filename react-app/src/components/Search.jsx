import { useState, useEffect } from "react";
import { fetchData } from "../services/apiService";
import {
  faMagnifyingGlass,
  faUser,
  faPhotoFilm,
} from "@fortawesome/free-solid-svg-icons";
import Pool from "./Pool";
import {
  SearchContainer,
  SearchBox,
  SearchIcon,
  SearchInput,
  PoolList,
  PoolItem,
  PoolItemContent,
  PoolIconInfo,
  ItemIcon,
} from "../styled/Search";

export default function Search() {
  const [pools, setPools] = useState([]);
  const [poolKeys, setPoolKeys] = useState([]);
  const [singlePoolView, setSinglePoolView] = useState(false);
  const [poolInfo, setPoolInfo] = useState([]);

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
                    <PoolIconInfo>
                      <ItemIcon icon={faPhotoFilm} />
                      <h3 buttondata={pool.Name}>{pool.SourceName}</h3>
                    </PoolIconInfo>
                    <PoolIconInfo>
                      <ItemIcon icon={faUser} />
                      <h3 buttondata={pool.Name}>{pool.Host}</h3>
                    </PoolIconInfo>
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

  // Event handler when user clicks on a single pool
  async function handleClickPoolCell(e) {
    try {
      const response = await fetchData(
        "getPoolInfo",
        e.target.getAttribute("buttondata")
      );
      if (response) {
        setPoolInfo(response);
      }
    } catch {
      console.error("Unable to retrieve pool data.");
    }

    setSinglePoolView(true);
  }

  // Event handler sent as props over to Pool component to bring back to search
  function handleArrowClick(e) {
    setSinglePoolView(false);
  }

  return (
    <div>
      <SearchContainer
        className="searchContainer"
        style={{ display: singlePoolView ? "none" : "flex" }}
      >
        <SearchBox>
          <SearchIcon icon={faMagnifyingGlass} />
          <SearchInput type="text" placeholder="Search Pools..." />
        </SearchBox>
        <PoolList>{pools}</PoolList>
      </SearchContainer>
      {singlePoolView ? (
        <Pool data={poolInfo} onClick={handleArrowClick} />
      ) : (
        <div style={{ display: "none" }} />
      )}
    </div>
  );
}
