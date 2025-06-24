import { useState, useEffect } from "react";
import {
  fetchData,
  fetchAllData as fetchAllPools,
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
  const [pools, setPools] = useState([]);
  const [poolKeys, setPoolKeys] = useState([]);
  const [singlePoolView, setSinglePoolView] = useState(false);
  const [poolInfo, setPoolInfo] = useState([]);

  // Loads all pools upon screen reload
  useEffect(() => {
    async function getPools() {
      try {
        const response = await fetchAllPools();
        if (response) {
          Array.from(response).forEach((pool) => {
            if (!poolKeys.includes(pool.id)) {
              setPools((prevPools) => [
                ...prevPools,
                <PoolItem
                  key={pool.id}
                  onClick={handleClickPoolCell}
                  buttondata={pool.id}
                >
                  <h2 style={{ color: "hotpink" }} buttondata={pool.id}>
                    {pool.name}
                  </h2>
                  <PoolItemContent buttondata={pool.id}>
                    <PoolIconInfo>
                      <ItemIcon icon={faPhotoFilm} />
                      <h3 buttondata={pool.id}>{pool.sourceName}</h3>
                    </PoolIconInfo>
                    <PoolIconInfo>
                      <ItemIcon icon={faUser} />
                      <h3 buttondata={pool.id}>{pool.hostFK}</h3>
                    </PoolIconInfo>
                  </PoolItemContent>
                </PoolItem>,
              ]);

              setPoolKeys((prevKeys) => [...prevKeys, pool.id]);
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
      console.log(response);
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
