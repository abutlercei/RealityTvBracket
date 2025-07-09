import { useEffect, useState } from "react";
import { PageContainer, TableContainer, SingleCellRow } from "../styled/Home";
import {
  Table,
  TableHeader,
  TableCell,
  AlternateRow,
} from "../styled/PoolTable";
import Pool from "./Pool.jsx";
import { fetchData } from "../services/poolService.js";
import { fetchSummaryView } from "../services/poolService";

export default function Home() {
  const username = import.meta.env.VITE_USERNAME;

  const [totals, setTotals] = useState({
    singleContestantPoints: 0,
    singleContestantAverageRank: 0.0,
    bracketPoints: 0,
    bracketTotalAccuracy: "0 / 0",
    allPools: [],
  });
  const [members, setMembers] = useState([]);
  const [bracketTables, setBracketTables] = useState({});
  // Change name to reflect view
  const [singlePoolView, setSinglePoolView] = useState(false);
  const [poolInfo, setPoolInfo] = useState([]);
  const [rowHighlighted, setRowHighlighted] = useState(null);

  // Getting summary data upon refresh
  useEffect(() => {
    async function getSummary() {
      try {
        const response = await fetchSummaryView(username);
        if (response) {
          setTotals(response);
        }
      } catch {
        console.error("Summary data failed to load");
      }
    }
    getSummary();
  }, []);

  // Adding values to states displaying summary once totals is updated
  useEffect(() => {
    setMembers([]);
    updateSummaryValues();
  }, [totals]);

  // Logic for effect updating summary values
  function updateSummaryValues() {
    totals["allPools"].forEach((row) => {
      if (row["isBracketStyle"]) {
        const rowObj = { allCorrect: 0, allTotal: 0, points: 0 };
        const userPoints = {};

        row["brackets"].forEach((bracket) => {
          const { userFK, isCorrect, points, OrderOut } = bracket;

          if (isCorrect) {
            userPoints[userFK] = (userPoints[userFK] || 0) + points;
          }

          if (userFK === username) {
            rowObj.allTotal++;
            if (isCorrect) {
              rowObj.allCorrect++;
              rowObj.points += points;
            }
          }
        });

        const sortedEntries = Object.entries(userPoints).sort(
          ([, a], [, b]) => b - a
        );
        const userRanks = {};
        let rank = 1;

        sortedEntries.forEach(([user, points], index) => {
          if (index > 0 && points === sortedEntries[index - 1][1]) {
            userRanks[user] = userRanks[sortedEntries[index - 1][0]];
          } else {
            userRanks[user] = rank;
          }
          rank++;
        });

        if (!bracketTables[row.id]) {
          setBracketTables((prev) => ({
            ...prev,
            [row.id]: {
              name: row.name,
              accuracy: `${rowObj.allCorrect} / ${rowObj.allTotal}`,
              rank: userRanks[username],
              points: rowObj.points,
            },
          }));
        }
      } else {
        row["members"].forEach((member) => {
          if (member["usernameFK"] === username) {
            member["name"] = row["name"];
            setMembers((prev) => [...prev, member]);
          }
        });
      }
    });
  }

  // Event handler when user clicks on pool row
  async function handleClickPool(e) {
    try {
      const response = await fetchData(e.target.getAttribute("buttondata"));
      setPoolInfo(response);
    } catch {
      console.error("Unable to retrieve pool data");
    }
    setRowHighlighted(null);
    setSinglePoolView(true);
  }

  // Event handler sent as props over to Pool component
  function handleArrowClick(e) {
    setSinglePoolView(false);
  }

  // Add conditional display using singlePoolView and add Pool object at bottom
  return (
    <PageContainer>
      {!singlePoolView && <h1>Reality Fights</h1>}
      {!singlePoolView && (
        <TableContainer>
          <Table>
            <TableHeader>
              <tr>
                <SingleCellRow colSpan={3}>Totals</SingleCellRow>
              </tr>
              <tr>
                <TableCell>Pool Type</TableCell>
                <TableCell>Points</TableCell>
                <TableCell>Average Rank/Accuracy</TableCell>
              </tr>
            </TableHeader>
            <tbody>
              <AlternateRow>
                <TableCell>Single Contestant</TableCell>
                <TableCell>{totals["singleContestantPoints"]}</TableCell>
                <TableCell>
                  {new Intl.NumberFormat("en-US", {
                    style: "decimal",
                    maximumFractionDigits: 2,
                  }).format(totals["singleContestantAverageRank"])}
                </TableCell>
              </AlternateRow>
              <AlternateRow>
                <TableCell>Bracket</TableCell>
                <TableCell>{totals["bracketPoints"]}</TableCell>
                <TableCell>{totals["bracketTotalAccuracy"]}</TableCell>
              </AlternateRow>
            </tbody>
          </Table>
          {totals["allPools"].length > 0 && members.length > 0 && (
            <Table>
              <TableHeader>
                <tr>
                  <SingleCellRow colSpan={4}>Pools</SingleCellRow>
                </tr>
                <tr>
                  <TableCell>Name</TableCell>
                  <TableCell>Contestant</TableCell>
                  <TableCell>Rank</TableCell>
                  <TableCell>Points</TableCell>
                </tr>
              </TableHeader>
              <tbody>
                {Array.from(members).map((row) => (
                  <AlternateRow
                    key={row["poolNameFK"]}
                    onClick={handleClickPool}
                    buttondata={row["poolNameFK"]}
                    onMouseEnter={() => {
                      setRowHighlighted(row["poolNameFK"]);
                    }}
                    onMouseLeave={() => setRowHighlighted(null)}
                    style={{
                      backgroundColor:
                        rowHighlighted === row["poolNameFK"]
                          ? "hotpink"
                          : "#6962ad",
                    }}
                  >
                    <TableCell buttondata={row["poolNameFK"]}>
                      {row.name}
                    </TableCell>
                    <TableCell buttondata={row["poolNameFK"]}>
                      {row.contestant}
                    </TableCell>
                    <TableCell buttondata={row["poolNameFK"]}>
                      {row.rank}
                    </TableCell>
                    <TableCell buttondata={row["poolNameFK"]}>
                      {row.points}
                    </TableCell>
                  </AlternateRow>
                ))}
              </tbody>
            </Table>
          )}
          {totals["allPools"].length > 0 &&
            Object.entries(bracketTables).length > 0 && (
              <Table>
                <TableHeader>
                  <tr>
                    <SingleCellRow colSpan={4}>Brackets</SingleCellRow>
                  </tr>
                  <tr>
                    <TableCell>Name</TableCell>
                    <TableCell>Accuracy</TableCell>
                    <TableCell>Rank</TableCell>
                    <TableCell>Points</TableCell>
                  </tr>
                </TableHeader>
                <tbody>
                  {Object.entries(bracketTables).map(([key, value]) => (
                    <AlternateRow
                      key={key}
                      onClick={handleClickPool}
                      buttondata={key}
                      onMouseEnter={() => setRowHighlighted(key)}
                      onMouseLeave={() => setRowHighlighted(null)}
                      style={{
                        backgroundColor:
                          rowHighlighted === key ? "hotpink" : "#6962ad",
                      }}
                    >
                      <TableCell buttondata={key}>{value["name"]}</TableCell>
                      <TableCell buttondata={key}>
                        {value["accuracy"]}
                      </TableCell>
                      <TableCell buttondata={key}>{value["rank"]}</TableCell>
                      <TableCell buttondata={key}>{value["points"]}</TableCell>
                    </AlternateRow>
                  ))}
                </tbody>
              </Table>
            )}
        </TableContainer>
      )}
      {singlePoolView && (
        <Pool data={poolInfo} onClick={handleArrowClick}></Pool>
      )}
    </PageContainer>
  );
}
