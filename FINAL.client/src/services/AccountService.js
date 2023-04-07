import { AppState } from '../AppState'
import { Account } from '../models/Account.js'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'
import { vaultsService } from './VaultsService'

class AccountService {
  async getAccount() {
    try {
      const res = await api.get('/account')
      AppState.account = new Account(res.data)
      vaultsService.getMyVaults()
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }
}

export const accountService = new AccountService()
