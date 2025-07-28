import { useState, useEffect } from "react";
import {
  Table,
  TableHeader,
  TableCell,
  AlternateRow,
} from "../styled/PoolTable";

export default function PoolTable(props) {
  const [tableHost, setTableHost] = useState();
  // Preserves initial row state when host row is highlighted
  const [initialRowColor, setInitialRowColor] = useState();

  // Setting tableHost state on table rendering
  useEffect(() => {
    setTableHost(props.username);
  }, []);

  // Changing background (highlighting) host row when highlight state changes
  useEffect(() => {
    var hostRowElement = document.getElementsByClassName("tableHost")[0];

    if (hostRowElement) {
      if (props.highlightState) {
        if (!initialRowColor) {
          setInitialRowColor(hostRowElement.style.backgroundColor);
        }
        hostRowElement.style.backgroundColor = "hotpink";
        hostRowElement.style.color = "white";
      } else if (hostRowElement) {
        hostRowElement.style.backgroundColor = initialRowColor;
        hostRowElement.style.color = "#83c0c1";
      }
    }
  }, [props.highlightState]);

  return (
    <Table>
      <TableHeader>
        <tr>
          <TableCell>Name</TableCell>
          <TableCell>
            {props.isBracketStyle ? "Accuracy" : "Contestant"}
          </TableCell>
          <TableCell>Rank</TableCell>
          <TableCell>Points</TableCell>
        </tr>
      </TableHeader>
      <tbody>
        {Array.from(props.tableData).map((row, index) =>
          index % 2 !== 0 ? (
            <tr
              key={index}
              className={row.name === tableHost ? "tableHost" : ""}
            >
              <TableCell>
                {props.displayTitle ? row.poolName : row.userPreferredName}
              </TableCell>
              <TableCell>{row.contestant}</TableCell>
              <TableCell>{row.rank}</TableCell>
              <TableCell>{row.points}</TableCell>
            </tr>
          ) : (
            <AlternateRow
              key={index}
              className={row.name === tableHost ? "tableHost" : ""}
            >
              <TableCell>
                {props.displayTitle ? row.poolName : row.userPreferredName}
              </TableCell>
              <TableCell>{row.contestant}</TableCell>
              <TableCell>{row.rank}</TableCell>
              <TableCell>{row.points}</TableCell>
            </AlternateRow>
          )
        )}
      </tbody>
    </Table>
  );
}
