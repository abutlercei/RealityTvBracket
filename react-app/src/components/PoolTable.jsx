import { useState, useEffect } from "react";
import {
  Table,
  TableHeader,
  TableCell,
  AlternateRow,
} from "../styled/PoolTable";

export default function PoolTable(props) {
  const [tableHost, setTableHost] = useState();
  const [initialRowColor, setInitialRowColor] = useState(); // Preserves initial row state

  // Setting tableHost state on table rendering
  useEffect(() => {
    setTableHost(props.tableData[0]["Host"]);
  }, []);

  // Changing background (highlighting) host row when highlight state changes
  useEffect(() => {
    var hostRowElement = document.getElementsByClassName("tableHost")[0];

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
  }, [props.highlightState]);

  return (
    <Table>
      <TableHeader>
        <tr>
          <TableCell>Name</TableCell>
          <TableCell>Contestant</TableCell>
          <TableCell>Rank</TableCell>
          <TableCell>Points</TableCell>
        </tr>
      </TableHeader>
      <tbody>
        {Array.from(props.tableData).map((row, index) =>
          index % 2 !== 0 ? (
            <tr
              key={index}
              className={row.Username === tableHost ? "tableHost" : ""}
            >
              <TableCell>{row.Name}</TableCell>
              <TableCell>{row.Contestant}</TableCell>
              <TableCell>{row.Rank}</TableCell>
              <TableCell>{row.Points}</TableCell>
            </tr>
          ) : (
            <AlternateRow
              key={index}
              className={row.Username === tableHost ? "tableHost" : ""}
            >
              <TableCell>{row.Name}</TableCell>
              <TableCell>{row.Contestant}</TableCell>
              <TableCell>{row.Rank}</TableCell>
              <TableCell>{row.Points}</TableCell>
            </AlternateRow>
          )
        )}
      </tbody>
    </Table>
  );
}
