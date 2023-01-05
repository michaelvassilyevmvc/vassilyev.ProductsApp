﻿using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service;

public sealed class ServiceManager : IServiceManager
{
	private readonly Lazy<IProductService> _companyService;

	public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
	{
		_companyService = new Lazy<IProductService>(() =>
			new ProductService(repositoryManager, logger, mapper));
	}

	public IProductService ProductService => _companyService.Value;
}