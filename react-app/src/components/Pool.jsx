import {
  PageContainer,
  PoolName,
  PageContent,
  ContentBox,
  PoolSource,
  PoolHost,
  PageLink,
  PoolBio,
  JoinButton,
} from "../styled/Pool";
import PoolTable from "./PoolTable";

export default function Pool() {
  return (
    <PageContainer>
      <PoolName>Lone Survivors (Pool Name)</PoolName>
      <PageContent>
        <ContentBox>
          <PoolSource>
            Pool from{" "}
            <PageLink
              href="https://en.wikipedia.org/wiki/Survivor:_Borneo"
              target="_blank"
            >
              Survivor Season 1
            </PageLink>
          </PoolSource>
          <PoolHost>
            Host: <PageLink href="./profile">abutler</PageLink>
          </PoolHost>
          <PoolBio>
            Join this test league to see other features within the environment.
            As Survivor Season 1 aired in 2000, this current league is closed
            for actual participants. This pool shows a type where participants
            gain points as their contestant stays in the competition. The other
            type of pool allows players to guess when contestants get eliminated
            similar to NCAA brackets.
          </PoolBio>
          <JoinButton>Request to Join</JoinButton>
        </ContentBox>
        <ContentBox>
          <PoolSource>Leaderboard</PoolSource>
          <PoolTable />
        </ContentBox>
      </PageContent>
    </PageContainer>
  );
}
