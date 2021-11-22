export interface Events {
  id: number,
  img_event: string;
  name: string;
  description: string;
  local: string;
  data: string;
}

export interface EventDetails {
  id: number;
  name: string;
  description: string;
  local: string;
  data: string;
  organization: string;
  remoto: boolean;
  img_event: string;
  img_organizador: string;
  qtd_participants: number;
  participants: ParticipantsEvent[]
}

export interface ParticipantsEvent {
  id: number;
  url: string;
  name: string;
}

export interface MyEvents {
  id: number;
  name: string;
  description: string;
  local: string;
  data: string;
}

export interface EventBooking {

}
