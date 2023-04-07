import { api } from './AxiosService'
import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { Keep } from '../models/Keep'
import { vaultsService } from './VaultsService'


class KeepsService {


    async getKeeps() {
        const res = await api.get('api/keeps')
        AppState.keeps = res.data.map(k => new Keep(k))
        logger.log(AppState.keeps)
    }

    async getKeepById(id) {
        AppState.keep = {}
        const res = await api.get('api/keeps/' + id)
        AppState.keep = res.data
        logger.log(AppState.keep)
    }
    async deleteKeep(id) {
        const res = await api.delete('api/keeps/' + id)
        vaultsService.getKeepsByProfile(AppState.account.id)
    }
    async createKeep(formData) {
        const res = await api.post('api/keeps', formData)
        logger.log(res.data)
    }
}

export const keepsService = new KeepsService