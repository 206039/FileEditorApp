﻿using AutoMapper;
using FileEditorApp.Server.Repositories;
using FileEditorApp.Shared.Domain;
using FileEditorApp.Shared.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FileEditorApp.Server.Services
{
    public class FileService : IFileService
    {
        private readonly IDatabaseFileRepository _dbFileRepository;
        private readonly IFileRepository _fileRepository;
        private readonly IMapper _mapper;

        public FileService(IDatabaseFileRepository dbFileRepository, IFileRepository fileRepository, IMapper mapper)
        {
            _dbFileRepository = dbFileRepository;
            _fileRepository = fileRepository;
            _mapper = mapper;
        }
        public async Task CreateFileAsync(int userId, string fileName)
        {
            var uriFileName = Guid.NewGuid().ToString();
            var uri = Path.Combine("Files", uriFileName);
            var dbFile = new DatabaseFile(userId, fileName, uri);
            await _dbFileRepository.AddAsync(dbFile);
            _fileRepository.CreateFile(dbFile.Uri);
        }

        public async Task<IEnumerable<FileDto>> GetAsync(int userId)
            => _mapper.Map<IEnumerable<FileDto>>(await _dbFileRepository.GetAsync(userId));
    }
}