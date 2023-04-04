import { api } from './AxiosService'
import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { Keep } from '../models/Keep'


class KeepsService {


    async getKeeps() {
        const res = await api.get('api/keeps')
        AppState.keeps = res.data.map(k => new Keep(k))
        logger.log(AppState.keeps)
    }

    async getKeepById(id) {
        const res = await api.get('api/keeps/' + id)
        AppState.keep = res.data
        logger.log(AppState.keep)
    }
}

export const keepsService = new KeepsService