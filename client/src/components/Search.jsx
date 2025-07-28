import { useState, useEffect } from "react";
import {
  fetchData,
  fetchAllData as fetchAllPools,
  fetchSearchResults,
} from "../services/poolService.js";
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
  const [searchEmpty, setSearchEmpty] = useState(true);
  const [pools, setPools] = useState([]);
  const [searchResults, setSearchResults] = useState([]);
  const [poolKeys, setPoolKeys] = useState([]);
  const [searchKeys, setSearchKeys] = useState([]);
  const [singlePoolView, setSinglePoolView] = useState(false);
  const [poolInfo, setPoolInfo] = useState([]);

  // Loads all pools upon screen reload
  useEffect(() => {
    async function getPools() {
      try {
        const response = await fetchAllPools();
        if (response) {
          Array.from(response).forEach((pool) => {
            if (!poolKeys.includes(pool.poolId)) {
              setPools((prevPools) => [
                ...prevPools,
                <PoolItem
                  key={pool.poolId}
                  onClick={handleClickPoolCell}
                  buttondata={pool.poolId}
                >
                  <h2 style={{ color: "hotpink" }} buttondata={pool.poolId}>
                    {pool.poolName}
                  </h2>
                  <PoolItemContent buttondata={pool.poolId}>
                    <PoolIconInfo>
                      <ItemIcon icon={faPhotoFilm} />
                      <h3 buttondata={pool.poolId}>{pool.sourceName}</h3>
                    </PoolIconInfo>
                    <PoolIconInfo>
                      <ItemIcon icon={faUser} />
                      <h3 buttondata={pool.poolId}>{pool.hostUsername}</h3>
                    </PoolIconInfo>
                  </PoolItemContent>
                </PoolItem>,
              ]);

              setPoolKeys((prevKeys) => [...prevKeys, pool.poolId]);
            }
          });
        }
      } catch {
        console.error("Pools failed to load");
        setSinglePoolView(false);
      }
    }
    getPools();
  }, []);

  // Event handler when user clicks on a single pool
  async function handleClickPoolCell(e) {
    try {
      const response = await fetchData(e.target.getAttribute("buttondata"));
      setPoolInfo(response);
    } catch {
      console.error("Unable to retrieve pool data.");
    }
    setSinglePoolView(true);
  }

  // Event handler sent as props over to Pool component to bring back to search
  function handleArrowClick(e) {
    setSinglePoolView(false);
  }

  // Event handler upon input change to handle user searches
  async function handleSearch(e) {
    if (e.target.value !== "") {
      setSearchEmpty(false);
      try {
        const response = await fetchSearchResults(e.target.value);
        if (response) {
          var newSearchKeys = [];
          Array.from(response).forEach((pool) => {
            if (!newSearchKeys.includes(pool.poolId)) {
              newSearchKeys.push(pool.poolId);
            }
          });

          if (
            searchKeys.length !== newSearchKeys.length ||
            !newSearchKeys.every(
              (element, index) => element === searchKeys[index]
            )
          ) {
            setSearchResults([]);
            setSearchKeys(newSearchKeys);
            Array.from(response).forEach((pool) => {
              if (newSearchKeys.includes(pool.poolId)) {
                setSearchResults((prevPools) => [
                  ...prevPools,
                  <PoolItem
                    key={pool.poolId}
                    onClick={handleClickPoolCell}
                    buttondata={pool.poolId}
                  >
                    <h2 style={{ color: "hotpink" }} buttondata={pool.poolId}>
                      {pool.poolName}
                    </h2>
                    <PoolItemContent buttondata={pool.poolId}>
                      <PoolIconInfo>
                        <ItemIcon icon={faPhotoFilm} />
                        <h3 buttondata={pool.poolId}>{pool.sourceName}</h3>
                      </PoolIconInfo>
                      <PoolIconInfo>
                        <ItemIcon icon={faUser} />
                        <h3 buttondata={pool.poolId}>{pool.hostUsername}</h3>
                      </PoolIconInfo>
                    </PoolItemContent>
                  </PoolItem>,
                ]);
              }
            });
          }
        }
      } catch {
        console.error("Search results failed to load.");
      }
    } else {
      setSearchEmpty(true);
    }
  }

  return (
    <div>
      <SearchContainer
        className="searchContainer"
        style={{ display: singlePoolView ? "none" : "flex" }}
      >
        <SearchBox>
          <SearchIcon icon={faMagnifyingGlass} />
          <SearchInput
            type="text"
            placeholder="Search Pools..."
            onChange={handleSearch}
          />
        </SearchBox>
        <PoolList>{searchEmpty ? pools : searchResults}</PoolList>
      </SearchContainer>
      {singlePoolView ? (
        <Pool data={poolInfo} onClick={handleArrowClick} />
      ) : (
        <div style={{ display: "none" }} />
      )}
    </div>
  );
}
